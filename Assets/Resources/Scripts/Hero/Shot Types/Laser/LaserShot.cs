using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : IShotType
{
    List<Shot> _allShots;
    int _shotAmount;

    Model _model;
    float _cooldown;
    float _scale;
    float _shotMaxTime;
    float _distance;

    public LaserShot(int shotAmount, float cooldown, float scale, float shotMaxTime, float distance)
    {
        _allShots = new List<Shot>();
        _shotAmount = shotAmount;
        _cooldown = cooldown;
        _scale = scale;
        _shotMaxTime = shotMaxTime;
        _distance = distance;
    }

    public IShotType SetModel(Model model)
    {
        _model = model;
        for (int i = 0; i < _shotAmount; i++)
        {
            _allShots.Add(null);
        }
        return this;
    }

    public void Shoot()
    {
        Vector3 shotPos = new Vector3(_model.transform.position.x - (_allShots.Count * _distance - _distance) / 2 , _model.transform.position.y);

        if (_model.secCooldown < _model.secMaxCooldown)
        {
            _model.secCooldown += Time.deltaTime;
        }
        else
        {
            CallBullet(shotPos,0);
            PowerChange(_cooldown, _scale, _shotMaxTime);
            _model.secCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        for (int i = 0; i < _allShots.Count; i++)
        {
            _allShots[i] = _model.pool.GetObject();
            _allShots[i].movementOptions.Clear();
            _allShots[i].spawner = _model;
            _allShots[i].SetImperviousness(true).UnitDefiner(_model.mySecondaryShot);
            _allShots[i].transform.position = pos +  new Vector3( i * _distance, 0.1f);
        }
    }

    void PowerChange(float cd, float scale, float shotMaxTime)
    {
        _model.secMaxCooldown = cd;

        for (int i = 0; i < _allShots.Count; i++)
        {
            _allShots[i].StartCoroutine(_allShots[i].ReturnTimer(shotMaxTime));
            _allShots[i].transform.localScale = new Vector3(scale, _allShots[i].transform.localScale.y);
        }
    }
}
