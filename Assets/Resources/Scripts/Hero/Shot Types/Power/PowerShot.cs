using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShot : IShotType
{
    Model _model;
    float _separation;
    float _cooldown;

    public PowerShot(float separation, float cooldown)
    {
        _separation = separation;
        _cooldown = cooldown;
    }

    public void Shoot()
    {
        if (_model.secCooldown < _cooldown)
        {
            _model.secCooldown += Time.deltaTime;
        }
        else
        {
            Vector3 pos1 = _model.transform.position + new Vector3(-0.3f, 0.25f);
            Vector3 pos2 = _model.transform.position + new Vector3(0.3f, 0.25f);
            CallBullet(pos1, -1);
            CallBullet(pos2, 1);
            _model.secCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {        
        Shot shotTemp = _model.pool.GetObject();
        shotTemp.transform.position = pos + new Vector3(Mathf.Sin(Time.time) * startingNum * _separation, 0.4f);
        shotTemp.spawner = _model;
        shotTemp.SetImperviousness(false).UnitDefiner(_model.mySecondaryShot);
        shotTemp.movementOptions.Clear();
        shotTemp.transform.rotation = Quaternion.Euler(0, 0, 0);
        shotTemp.SetShotType(new Straight(8, shotTemp.transform.up).TransformAssigner(shotTemp.transform));        
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        return this;
    }
}