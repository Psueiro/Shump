using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public delegate void Effect(bool b);
    public Effect effects;

    IController _controller;
    public Pool<Shot> pool;
    public Shot basicShot;
    public Shot myShot;
    public Shot mySecondaryShot;
    public Shot myFocusShot;

    public List<IShotType> allMainShots;
    public List<IShotType> allSecondaryShots;
    public List<IShotType> allFocusShots;

    public IShotType shotType;
    public IShotType secondaryShotType;
    public IShotType focusShotType;

    public float respawnTimer;

    public float speed;
    public float maxSpeed;

    public float cooldown;
    public float maxCooldown;

    public float secCooldown;
    public float secMaxCooldown;

    public float focCooldown;
    public float focMaxCooldown;

    public float score;
    public float power;
    public float damage;
    public float bombDamage;
    public int lives;
    public int maxLives;
    public int bombs;
    public int maxBombs;
    public float bombDuration;
    public float bombMaxDuration;
    public BoxCollider2D boxC;

    public bool bombing;
    public bool dying;

    public Bomb bomb;
    PowerManagement _p;

    float _dyingWindow;

    void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
        _controller = new ControllerPlayer(this);
        _p = new PowerManagement(this);
        new View(this);
        SpreadMode();
    }

    void Update()
    {
        _controller.OnUpdate();
        PointManager();
        DyingWindow();
        _p.PowerManager();
    }

    public void CallBomb()
    {
        if (bombs > 0 && !bombing && Time.timeScale > 0)
        {
            bomb.Activate(true);
            bombDuration = 0;
            bombing = true;
            EventManager.TriggerEvent("Bomb");
            bombs--;
        }
    }

    void DyingWindow()
    {
        if (dying)
            _dyingWindow += Time.deltaTime;

        if (_dyingWindow > 0.1f) Die();
    }

    public IEnumerator Respawning()
    {
        yield return new WaitForSeconds(respawnTimer);
        effects(true);
    }

    void Die()
    {
        effects(false);
        power -= 20;
        bombs = maxBombs;
        lives--;
        cooldown = -1;
        focCooldown = 0;
        secCooldown = 0;
        EventManager.TriggerEvent("Death");
        _dyingWindow = 0;
        dying = false;
    }

    public void Pause()
    {
        EventManager.TriggerEvent("Pause");
    }

    void PointManager()
    {
        if (lives > 8) lives = 8;
        if (power < 0) power = 0;
        if (power > 60) power = 60;
        if (bombs > 8) bombs = 8;
        if (bombs < 0) bombs = 0;
        if(score == 100)
        {
            lives++;
            score = 0;
        }
    }

    public void Shoot() //Ienumerator??
    {
        if(Time.timeScale>0)
        {
            shotType.Shoot();
            if(speed < maxSpeed)        
            focusShotType.Shoot();               
            else secondaryShotType.Shoot();
        }
    }

    public Shot ShotFactory()
    {
        return Instantiate(basicShot).SetParent(transform.GetChild(0));
    }

    public void ReturnShot(Shot s)
    {
        pool.ReturnObject(s);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 8 || c.gameObject.layer == 10)
        {
            dying = true;
            _dyingWindow = 0;
        }
    }

    public void Move(Vector3 v)
    {
        if(transform.position.x <= Screen.width && transform.position.y <= Screen.height)
        transform.position += v * speed * Time.deltaTime;
    }

    public void SpreadMode()
    {
        speed = maxSpeed;
    }

    public void FocusMode()
    {
        speed = maxSpeed / 2;
    }

    public Model ShotTypeSetter(IShotType first, IShotType second, IShotType third)
    {
        if(allMainShots == null) allMainShots = new List<IShotType>();
        else allMainShots.Clear();
        allMainShots.Add(first.SetModel(this));
        allMainShots.Add(second.SetModel(this));
        allMainShots.Add(third.SetModel(this));
        shotType = first;
        return this;
    }

    public Model SecondaryShotTypeSetter(IShotType first, IShotType second, IShotType third)
    {
        if (allSecondaryShots == null) allSecondaryShots = new List<IShotType>();
        else allSecondaryShots.Clear();
        allSecondaryShots.Clear();
        allSecondaryShots.Add(first.SetModel(this));
        allSecondaryShots.Add(second.SetModel(this));
        allSecondaryShots.Add(third.SetModel(this));
        secondaryShotType = first;
        return this;
    }

     public Model FocusShotTypeSetter(IShotType first, IShotType second, IShotType third)
    {
        if (allFocusShots == null) allFocusShots = new List<IShotType>();
        else allFocusShots.Clear();
        allFocusShots.Clear();
        allFocusShots.Add(first.SetModel(this));
        allFocusShots.Add(second.SetModel(this));
        allFocusShots.Add(third.SetModel(this));
        focusShotType = first;
        return this;
    }

    public Model SetBomb(IBomb b)
    {
        bomb.myBomb = b;
        bomb.myBomb.BombModelSetter(bomb);
        return this;
    }

    public Model MaxSpeedSetter(float spe)
    {
        maxSpeed = spe;
        speed = maxSpeed;
        return this;
    }

    public Model LivesSetter(int liv)
    {
        maxLives = liv;
        lives = maxLives;
        return this;
    }

    public Model BombsSetter(int bom)
    {
        maxBombs = bom;
        bombs = maxBombs;
        return this;
    }

    public Model MainShotCooldownSetter(float maxCd)
    {
        maxCooldown = maxCd;
        cooldown = maxCd;
        return this;
    }

    public Model SecondaryCooldownSetter(float maxSecCd)
    {
        secMaxCooldown = maxSecCd;
        secCooldown = secMaxCooldown;
        return this;
    }

    public Model FocusCooldownSetter(float maxFocCd)
    {
        focMaxCooldown = maxFocCd;
        return this;
    }

    public Model DamageSetter(float dmg)
    {
        damage = dmg;
        return this;
    }

    public Model HitboxSetter(float i)
    {
        boxC.size = new Vector2(i,i);
        return this;
    }

    public Model BombDamageSetter(float dmg)
    {
        bombDamage = dmg;
        return this;
    }

    public Model BombDurationSetter(float i)
    {
        bombMaxDuration = i;
        return this;
    }

    public Model ShotBulletSetter(Shot s, int stock)
    {
        myShot = s;
        if(pool == null)
        pool = new Pool<Shot>(ShotFactory, Shot.TurnOn, Shot.TurnOff, stock);
        return this;
    }

    public Model SecondaryShotBulletSetter(Shot s)
    {
        mySecondaryShot = s;
        return this;
    }

    public Model FocusBulletSetter(Shot s)
    {
        myFocusShot = s;
        return this;
    }
}

//setear olas de enemigos
//hacer spawners genericos
//setear look up table
//Trigger Event para reemplazar a la pausa