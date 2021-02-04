using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShot : IShotType
{
    Model _model;
    int _bulletAmount;
    float _separation;

    public FastShot(int bulletAmount, float separation)
    {
        _bulletAmount = bulletAmount;
        _separation = separation;
    }

    public void Shoot()
    {
        if (_model.secCooldown < _model.secMaxCooldown)
        {
            _model.secCooldown += Time.deltaTime;
        }
        else
        {
            CallBullet(_model.transform.position, Mathf.RoundToInt(_bulletAmount / 2));
            _model.secCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        for (int i = -startingNum; i < startingNum + 1; i++)
        {
            Shot shotTemp = _model.pool.GetObject();
            shotTemp.transform.position = pos + new Vector3( i * _separation, 0.4f);
            shotTemp.spawner = _model;
            shotTemp.SetImperviousness(true).UnitDefiner(_model.mySecondaryShot);
            shotTemp.movementOptions.Clear();
            shotTemp.transform.rotation = Quaternion.Euler(0, 0, 0);
            shotTemp.SetShotType(new Straight(8, shotTemp.transform.up).TransformAssigner(shotTemp.transform));
        }
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        return this;
    }
}
