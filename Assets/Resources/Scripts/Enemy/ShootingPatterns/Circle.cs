    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : IBulletPatterns
{
    BulletSpawner _spawner;
    BasicBullet _bullet;
    Transform _origin;
    int _amount;
    float _speed;
    Color _color;

    public Circle(BasicBullet b, int amount, float speed, Color c)
    {
        _bullet = b;
        _amount = amount;
        _speed = speed;
        _color = c;
    }

    public void BulletPattern()
    {
        for (int i = 0; i < _amount; i++)
        {
            var temBullet = _spawner.bulletPool.GetObject();
            temBullet.movementOptions.Clear();
            temBullet.UnitDefiner(_bullet);

            temBullet.GetComponent<SpriteRenderer>().color = _color;
            Vector3 pos;
            pos = new Vector3(_origin.position.x + Mathf.Sin(i + 0.5f), _origin.position.y + Mathf.Cos(i + 0.5f));
            temBullet.transform.position = pos;
            Vector3 dir;
            dir = (temBullet.transform.position-_origin.position).normalized;
            temBullet.AddMovement(new Straight(_speed, dir).TransformAssigner(temBullet.transform)).SetMovement(temBullet.movementOptions[0]);
            temBullet.transform.up = dir;

            //magic star (add to i for more rotation)
            //temBullet.SetRotation(360/_amount * (i));
        }
    }

    public IBulletPatterns SetTransform(Transform t)
    {
        _origin = t;
        return this;
    }

    public IBulletPatterns SetBulletSpawner(BulletSpawner b)
    {
        _spawner = b;
        return this;
    }
}
