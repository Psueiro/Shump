using UnityEngine;

[CreateAssetMenu(menuName = "Points/Laser")]
public class LaserWrapper : PointWrapper
{
    public Shot main;
    public Shot secondary;
    public Shot focus;

    public override void BonusSetter()
    {
        bonus = new BonusLaser(main, secondary, focus);
    }
}
