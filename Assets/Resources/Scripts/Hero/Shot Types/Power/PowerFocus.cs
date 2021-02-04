using UnityEngine;

public class PowerFocus : IShotType
{
    Model _model;
    float _separation;
    float _cooldown;

    public PowerFocus(float separation, float cooldown)
    {
        _separation = separation;
        _cooldown = cooldown;
    }

    public void Shoot()
    {
        if (_model.focCooldown < _cooldown)
        {
            _model.focCooldown += Time.deltaTime;
        }
        else
        {
            Vector3 pos1 = _model.transform.position + new Vector3(0, 0.25f);
            CallBullet(pos1, 1);
            _model.focCooldown = 0;
        }
    }

    public void CallBullet(Vector3 pos, int startingNum)
    {
        Shot shotTemp = _model.pool.GetObject();
        shotTemp.transform.position = pos + new Vector3(Random.Range(-_separation,_separation), 0.4f);
        shotTemp.spawner = _model;
        shotTemp.SetImperviousness(false).UnitDefiner(_model.myFocusShot);
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
