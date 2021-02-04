using UnityEngine;

public class PowerSetter : ShotSetter
{
    public override void SetShots()
    {
        allshots = new IShotType[6];

        allshots[0] = new PowerShot(0.2f, 0.5f);
        allshots[1] = new PowerShot(0.2f, 0.35f);
        allshots[2] = new PowerShot(0.2f, 0.2f);
        allshots[3] = new PowerFocus(0.2f, 0.3f);
        allshots[4] = new PowerFocus(0.2f, 0.25f);
        allshots[5] = new PowerFocus(0.2f, 0.2f);
        bomb = new Magicannon();
    }
}
