using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShot : IShotType
{
    Transform _b;
    float _maxTime;
    int _bulletAmount;
    Model _model;
    float _angle;

    public HomingShot(int bulletAmount, float angle, float maxTime)
    {
        _bulletAmount = bulletAmount;
        _angle = angle;
        _maxTime = maxTime;
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        return this;
    }

    public void Shoot()
    {
        Vector3 shotPos1 = new Vector3(_model.transform.position.x - 0.3f, _model.transform.position.y + 0.25f);
        Vector3 shotPos2 = new Vector3(_model.transform.position.x + 0.3f, _model.transform.position.y + 0.25f);

        if (_model.secCooldown < _model.secMaxCooldown)
        {
            _model.secCooldown += Time.deltaTime;
        }
        else
        {
            CallBullet(shotPos1, 1);
            CallBullet(shotPos2, -1);
            _model.secCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        for (int i = 1; i < _bulletAmount / 2 + 1; i++)
        {
            Shot secondaryShot = _model.pool.GetObject();
            secondaryShot.spawner = _model;
            secondaryShot.SetImperviousness(false).UnitDefiner(_model.mySecondaryShot);
            secondaryShot.movementOptions.Clear();
            secondaryShot.transform.rotation = Quaternion.Euler(0, 0, i * _angle * startingNum);
            secondaryShot.transform.position = pos;

            secondaryShot.StartCoroutine(secondaryShot.ReturnTimer(_maxTime));
            if (secondaryShot.FindTarget())
            {
                _b = secondaryShot.FindTarget();
                secondaryShot.SetShotType(new Homing(10).TargetSetter(_b).TransformAssigner(secondaryShot.transform));
            }
            else secondaryShot.SetShotType(new Straight(8, secondaryShot.transform.up).TransformAssigner(secondaryShot.transform));
        }
    }
}

