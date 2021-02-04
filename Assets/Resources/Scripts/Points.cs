using System.Collections;
using UnityEngine;

public class Points : PoolUnit
{
    Model _hero;
    IMovement _homing;
    public IMovement straight;
    PointSpawner _spawner;
    IBonus _bonus;

    private void Start()
    {
        EventManager.SubscribeToEvent("Bombing", HomeTohero);
        straight = new Straight(5, Vector3.up).TransformAssigner(transform);
        _homing = new Homing(20).TargetSetter(_hero.transform).TransformAssigner(transform);
        current = straight;
        StartCoroutine(ChangePath());
    }

    public Points SetSpawner(PointSpawner p)
    {
        _spawner = p;
        return this;
    }

    public Points SetParent(Transform t)
    {
        transform.parent = t.transform;
        return this;
    }

    void Update()
    {
        current.Movement();
    }

    IEnumerator ChangePath()
    {
        yield return new WaitForSeconds(0.5f);
        SetMovement(new Straight(5, -Vector3.up).TransformAssigner(transform));
    }

    public void HomeTohero()
    {
        current = _homing;
    }

    public Points HeroSetter(Model h)
    {
        _hero = h;
        return this;
    }

    public Points BonusSetter(IBonus b)
    {
        _bonus = b;
        return this;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.layer == 0 || c.gameObject.layer == 11)
        {
            _spawner.ReturnPoint(this);
        }
        if (c.gameObject.layer == 0)
            _bonus.Bonus(_hero);
    } 
}
