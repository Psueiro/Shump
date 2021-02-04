using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : IBulletPatterns
{
    BulletSpawner spawner;
    BasicBullet _bullet;
    float _speed;
    Vector3 _target;
    Vector3 _dir;
    Transform _origin;
    bool _dynamicTargeting;
    Color _color;

    public Aim(BasicBullet b, float speed, Color c)
    {
        _bullet = b;
        _speed = speed;
        _color = c;
    }

    public Aim SetTarget(Vector3 target)
    {
        _target = target;
        return this;
    }

    public void BulletPattern()
    {
        var temBullet = spawner.bulletPool.GetObject();
        temBullet.UnitDefiner(_bullet);
        temBullet.movementOptions.Clear();

        temBullet.transform.position = _origin.position;

        temBullet.GetComponent<SpriteRenderer>().color = _color;

        _dir = (_target - _origin.position).normalized;
        temBullet.AddMovement(new Straight(_speed,_dir).TransformAssigner(temBullet.transform)).SetMovement(temBullet.movementOptions[0]);
            temBullet.transform.up = _dir;
    }

    public IBulletPatterns SetTransform(Transform t)
    {
        _origin = t;
        return this;
    }

    public IBulletPatterns SetBulletSpawner(BulletSpawner b)
    {
        spawner = b;
        return this;
    }
}