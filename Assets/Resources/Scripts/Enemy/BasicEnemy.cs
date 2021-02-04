using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : PoolUnit
{
    BulletSpawner _bulletSpawner;
    EnemySpawner _enemySpawner;
    PointSpawner _pointSpawner;
    public Model _model;

    public float health;

    int _pointAmount;
    int _powerAmount;

    float _cooldown;
    float _maxCooldown;

    int _sentinelAmount;

    IBonus bonusDrop;

    public EnemyBehaviours behaviour;

    private void Start()
    {
        //SentinelSpawn();
        EventManager.SubscribeToEvent("Bombing", BombDamageWrapper);
    }

    void Update()
    {
        behaviour.TargetSetter(_model.transform.position);
        if (_cooldown >= _maxCooldown)
        {
            for (int i = 0; i < behaviour.allPatterns.Count; i++)
            {
                behaviour.allPatterns[i].SetBulletSpawner(_bulletSpawner).SetTransform(transform).BulletPattern();
            }
            _cooldown = 0;
        }
        else _cooldown += Time.deltaTime;

        for (int i = 0; i < behaviour.movementOptions.Count; i++)
        {
            behaviour.movementOptions[i].TransformAssigner(transform).Movement();
        }

        if (health <= 0)
        {
            Die();
            _enemySpawner.ReturnEnemy(this);
        }
    }

    public IEnumerator ChangeMovement(float time, MovementWrapper[] m)
    {
        yield return new WaitForSeconds(time);
        {
            behaviour.movementOptions.Clear();
            for (int i = 0; i < m.Length; i++)
            {
                behaviour.AddMovement(m[i].movement.TransformAssigner(transform));
            }
        }
    }

    public void SentinelSpawn()
    {
        for (int i = 0; i < _sentinelAmount; i++)
        {
            BasicEnemy sentinel = _enemySpawner.basicEnemyPool.GetObject();
            sentinel.UnitDefiner(_enemySpawner.sentinel.myType);
            sentinel.BehaviourSetter(_enemySpawner.sentinel.behaviour.Clone());
            sentinel.SetSpawner(_enemySpawner);
            sentinel.SetHealth(_enemySpawner.sentinel.health);
            sentinel.SetCooldown(_enemySpawner.sentinel.maxCooldown);
            if(behaviour.changeMovementWrappers.Length > 0)
                sentinel.StartCoroutine(ChangeMovement(0.4f, behaviour.changeMovementWrappers));
            Vector3 pos;
            pos = new Vector3(transform.position.x + Mathf.Sin(i + 0.5f), transform.position.y + Mathf.Cos(i + 0.5f));
            sentinel.transform.position = pos;

            if (_enemySpawner.sentinel.behaviour.changeMovementWrappers.Length > 0)
            {
                sentinel.StartCoroutine(sentinel.ChangeMovement(_enemySpawner.sentinel.movementTimeToChange, behaviour.changeMovementWrappers));
            }
        }
    }

    void Die()
    {
        for (int i = 0; i < _pointAmount; i++)
        {
            Points point = _pointSpawner.pointsPool.GetObject();
            if (_pointAmount > 1)
            {
                point.SetMovement(point.straight);
                point.BonusSetter(bonusDrop).UnitDefiner(_pointSpawner.pointParamDic[bonusDrop.ToString()]).SetLocation(new Vector3(transform.position.x + Random.Range(-1.5f, 2.5f), transform.position.y + Random.Range(-1.5f, 2.5f)));
            }
            else
            {
                point.SetMovement(point.straight);
                point.BonusSetter(bonusDrop).UnitDefiner(_pointSpawner.pointParamDic[bonusDrop.ToString()]).SetLocation(transform.position);
            }
            _model.power += _powerAmount;
        }
    }

    public BasicEnemy BehaviourSetter(EnemyBehaviours b)
    {
        behaviour = b;
        return this;
    }

    public BasicEnemy SetSpawner(EnemySpawner e)
    {
        _enemySpawner = e;
        return this;
    }

    public BasicEnemy SetBulletSpawner(BulletSpawner b)
    {
        _bulletSpawner = b;
        return this;
    }

    public BasicEnemy SetPointSpawner(PointSpawner p)
    {
        _pointSpawner = p;
        return this;
    }

    public BasicEnemy SetPointAmount(int i)
    {
        _pointAmount = i;
        return this;
    }

    public BasicEnemy SetPowerAmount(int i)
    {
        _powerAmount = i;
        return this;
    }

    public BasicEnemy BonusSetter(IBonus b)
    {
        bonusDrop = b;
        return this;
    }

    public BasicEnemy SetParent(Transform t)
    {
        transform.parent = t.transform;
        return this;
    }

    public BasicEnemy SetHealth(int i)
    {
        health = i;
        return this;
    }

    public BasicEnemy SetCooldown(float i)
    {
        _maxCooldown = i;
        return this;
    }

    public BasicEnemy SetSetinelAmount(int i)
    {
        _sentinelAmount = i;
        return this;
    }

    public BasicEnemy SetHero(Model h)
    {
        _model = h;
        return this;
    }

    public void TakeDamage(float i)
    {
        health -= i;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 11)
        {
            _enemySpawner.ReturnEnemy(this);
        }
    }

    public void BombDamageWrapper()
    {
        TakeDamage(_model.bombDamage * _model.bombMaxDuration);
    }
}
