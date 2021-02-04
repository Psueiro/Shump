using UnityEngine;

public class HomingSetter : ShotSetter
{
    public override void SetShots()
    {
        allshots = new IShotType[6];
        allshots[0] = new HomingShot(2,30,1.3f);
        allshots[1] = new HomingShot(4,30,1.3f);
        allshots[2] = new HomingShot(6,15,1.3f);
        allshots[3] = new HomingFocus(2,5,1.3f);
        allshots[4] = new HomingFocus(4, 5, 1.3f);
        allshots[5] = new HomingFocus(6, 5, 1.3f);
        bomb = new Seal();
    }
}
