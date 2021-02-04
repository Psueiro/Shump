using UnityEngine;

[CreateAssetMenu(menuName = "Points/Homing")]
public class HomingWrapper : PointWrapper
{
    public Shot main;
    public Shot secondary;
    public Shot focus;

    public override void BonusSetter()
    {
        bonus = new BonusHoming(main, secondary, focus);
    }
}
