using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFocus : IShotType
{
    Model _model;
    bool _impervious;
    float _separation;
    float _cooldown;

    public FastFocus(bool impervious, float separation, float cooldown)
    {
        _impervious = impervious;
        _separation = separation;
        _cooldown = cooldown;
    }

    public void Shoot()
    {
        if (_model.focCooldown < _model.focMaxCooldown)
        {
            _model.focCooldown += Time.deltaTime;
        }
        else
        {
            CallBullet(_model.transform.position, 0);
            _model.focCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        Shot shotTemp = _model.pool.GetObject();
        shotTemp.transform.position = pos + new Vector3(0 , _separation);
        shotTemp.spawner = _model;
        shotTemp.SetImperviousness(_impervious).UnitDefiner(_model.myFocusShot);
        shotTemp.movementOptions.Clear();
        shotTemp.transform.rotation = Quaternion.Euler(0, 0, 0);

        shotTemp.SetShotType(new Straight(8, shotTemp.transform.up).TransformAssigner(shotTemp.transform));
        if(_model.focCooldown != _cooldown) _model.FocusCooldownSetter(_cooldown);
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        return this;
    }
}
