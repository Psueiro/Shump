using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayAndPray : IBulletPatterns
{
    Transform _t;
    public BulletSpawner _spawner;
    float _speed;
    float _minRotation;
    float _maxRotation;
    BasicBullet _bullet;
    Color _color;

    public SprayAndPray(BasicBullet b, float speed, float minRotation, float maxRotation, Color color)
    {
        _speed = speed;
        _bullet = b;
        _minRotation = minRotation;
        _maxRotation = maxRotation;
        _color = color;
    }

    public void BulletPattern()
    {
        var temBullet = _spawner.bulletPool.GetObject();
        temBullet.movementOptions.Clear();
        temBullet.UnitDefiner(_bullet);
        temBullet.GetComponent<SpriteRenderer>().color = _color;

        temBullet.SetRotation(Random.Range(_minRotation, _maxRotation)).AddMovement(new Straight(_speed, temBullet.transform.up).TransformAssigner(temBullet.transform)).SetMovement(temBullet.movementOptions[0]);
        temBullet.transform.position = _t.transform.position;
    }

    public IBulletPatterns SetTransform(Transform t)
    {
        _t = t;
        return this;
    }

    public IBulletPatterns SetBulletSpawner(BulletSpawner b)
    {
        _spawner = b;
        return this;
    }
}
