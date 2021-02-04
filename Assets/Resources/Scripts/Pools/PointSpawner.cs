using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public App app;

    public Points point;
    public Points powerfulPowerUp;
    public Points homingPowerUp;
    public Points laserPowerUp;
    public Points fastPowerUp;

    public Pool<Points> pointsPool;

    public List<string> bonusList;
    public Dictionary<string, Points> pointParamDic = new Dictionary<string, Points>();


    void Start()
    {
        pointsPool = new Pool<Points>(PointFactory, Points.TurnOn,Points.TurnOff, 20);

        bonusList = new List<string>();
        bonusList.Add("BonusPoints");
        bonusList.Add("BonusHoming");
        bonusList.Add("BonusFast");
        bonusList.Add("BonusPower");
        bonusList.Add("BonusLaser");

        pointParamDic.Add(bonusList[0], point);
        pointParamDic.Add(bonusList[1], homingPowerUp);
        pointParamDic.Add(bonusList[2], fastPowerUp);
        pointParamDic.Add(bonusList[3], powerfulPowerUp);
        pointParamDic.Add(bonusList[4], laserPowerUp);
    }

    Points PointFactory()
    {
        return Instantiate(point).SetSpawner(this).HeroSetter(app.model).SetParent(transform.GetChild(0));
    }

    public void ReturnPoint(Points p)
    {
        pointsPool.ReturnObject(p);
    }
}
