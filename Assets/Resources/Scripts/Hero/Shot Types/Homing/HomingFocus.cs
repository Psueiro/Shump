using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFocus : IShotType
{
    Transform _b;
    float _maxTime;
    int _bulletAmount;
    Model _model;
    float _angle;

    public HomingFocus(int bulletAmount, float angle, float maxTime)
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
        Vector3 shotPos = new Vector3(_model.transform.position.x, _model.transform.position.y + 0.9f);

        if (_model.focCooldown < _model.focMaxCooldown)
        {
            _model.focCooldown += Time.deltaTime;
        }
        else
        {
            CallBullet(shotPos, 1);
            CallBullet(shotPos, -1);
            _model.focCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        for (int i = 1; i < _bulletAmount / 2 + 1; i++)
        {
            Shot secondaryShot = _model.pool.GetObject();
            secondaryShot.spawner = _model;
            secondaryShot.SetImperviousness(false).UnitDefiner(_model.myFocusShot);
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
