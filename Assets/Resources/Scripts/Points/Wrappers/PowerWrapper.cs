using UnityEngine;

[CreateAssetMenu(menuName = "Points/Power")]
public class PowerWrapper : PointWrapper
{
    public Shot main;
    public Shot secondary;
    public Shot focus;

    public override void BonusSetter()
    {
        bonus = new BonusPower(main, secondary,focus);
    }
}
