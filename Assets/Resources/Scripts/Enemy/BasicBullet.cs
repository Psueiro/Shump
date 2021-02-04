using UnityEngine;

public class BasicBullet : PoolUnit
{
    float _directionalSpeed;
    Model _hero;
    BulletSpawner _spawner;
    Pool<BasicBullet> _poolreference;

    private void Start()
    {
        EventManager.SubscribeToEvent("Bombing", Return);
    }

    void Update()
    {
        current.Movement();
    }

    public BasicBullet SetParent(Transform p)
    {
        transform.parent = p.transform;
        return this;
    }

    public BasicBullet PoolAssigner(Pool<BasicBullet> b)
    {
        _poolreference = b;
        return this;
    }

    public BasicBullet SetDirectionalSpeed(float f)
    {
        _directionalSpeed = f;
        return this;
    }

    public BasicBullet SetHero(Model h)
    {
        _hero = h;
        return this;
    }

    public BasicBullet SetSpawner(BulletSpawner b)
    {
        _spawner = b;
        return this;
    }

    public void Return()
    {
        _spawner.ReturnBullet(this);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 11)
        {
            Return();
        }
    }
}
