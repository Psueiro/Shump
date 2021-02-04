using UnityEngine;

public class FastSetter : ShotSetter
{
    public override void SetShots()
    {
        allshots = new IShotType[6];
        allshots[0] = new FastShot(1, 0.5f);
        allshots[1] = new FastShot(3, 0.5f);
        allshots[2] = new FastShot(5, 0.5f);
        allshots[3] = new FastFocus(true,0.9f,0.2f);
        allshots[4] = new FastFocus(true, 0.9f, 0.15f);
        allshots[5] = new FastFocus(true, 0.9f, 0.1f);
        bomb = new Seal();
    }
}
