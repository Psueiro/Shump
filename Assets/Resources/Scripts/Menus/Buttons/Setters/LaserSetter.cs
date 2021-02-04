using UnityEngine;

public class LaserSetter : ShotSetter
{
    public override void SetShots()
    {
        allshots = new IShotType[6];
        allshots[0] = new LaserShot(2,2.5f,2,1.3f, 0.6f);
        allshots[1] = new LaserShot(2, 2.3f, 4, 1.7f, 0.6f);
        allshots[2] = new LaserShot(2, 2.1f, 6, 2, 0.6f);
        allshots[3] = new LaserFocus(1, 2.3f,8,1.7f, 0);
        allshots[4] = new LaserFocus(1, 2.1f, 10, 2f, 0);
        allshots[5] = new LaserFocus(1, 2f, 12, 1.95f, 0);
        bomb = new Magicannon();
    }
}
