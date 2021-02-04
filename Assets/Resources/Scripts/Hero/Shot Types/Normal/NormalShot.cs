using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : IShotType
{
    Model _model;
    int _bulletAmount;
    float _angle;

    public NormalShot(int bulletAmount, float angle)
    {
        _bulletAmount = bulletAmount;
        _angle = angle;
    }

    public void Shoot()
    {
        if (_model.cooldown < _model.maxCooldown)
        {
            _model.cooldown += Time.deltaTime;
        }
        else
        {
            Vector3 shotPos = new Vector3(_model.transform.position.x, _model.transform.position.y + 0.4f);

            CallBullet(shotPos,  Mathf.RoundToInt(_bulletAmount / 2));
            _model.cooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        for (int i = -startingNum; i < startingNum +1; i++)
        {
            Shot shotTemp = _model.pool.GetObject();
            shotTemp.transform.position = pos;
            shotTemp.spawner = _model;
            shotTemp.SetImperviousness(false).UnitDefiner(_model.myShot);
            shotTemp.movementOptions.Clear();
            shotTemp.transform.rotation = Quaternion.Euler(0, 0, i * _angle);
            shotTemp.SetShotType(new Straight(8, shotTemp.transform.up).TransformAssigner(shotTemp.transform));
        }
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        return this;
    }    
}
