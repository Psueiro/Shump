using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : IBulletPatterns
{
    BulletSpawner _spawner;
    BasicBullet _bullet;
    Vector3 _t;
    float _speed;
    int _amount;
    bool _dynamic;

    public Spiral(BasicBullet b, float speed, int amount)
    {
        _bullet = b;
        _speed = speed;
        _amount = amount;
    }

    public Spiral SetDynamicSpawning(Transform o, bool d)
    {
        _dynamic = d;
        return this;
    }

    public void BulletPattern()
    {
        var temBullet = _spawner.bulletPool.GetObject();
        temBullet.movementOptions.Clear();
        temBullet.UnitDefiner(_bullet);
        temBullet.AddMovement(new Straight(_speed,temBullet.transform.up).TransformAssigner(temBullet.transform));
         temBullet.transform.position = _t;
        temBullet.SetRotation(Time.time * _amount);
    }

    public IBulletPatterns SetTransform(Transform t)
    {
        _t = t.transform.position;
        return this;
    }

    public IBulletPatterns SetBulletSpawner(BulletSpawner b)
    {
        _spawner = b;
        return this;
    }
}
