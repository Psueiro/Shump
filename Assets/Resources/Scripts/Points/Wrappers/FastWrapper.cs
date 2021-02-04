using UnityEngine;

[CreateAssetMenu(menuName = "Points/Fast")]
public class FastWrapper : PointWrapper
{
    public Shot main;
    public Shot secondary;
    public Shot focus;

    public override void BonusSetter()
    {
        bonus = new BonusFast(main, secondary, focus);
    }
}
