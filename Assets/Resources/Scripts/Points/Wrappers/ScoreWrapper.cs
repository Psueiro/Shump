using UnityEngine;

[CreateAssetMenu(menuName = "Points/Score")]
public class ScoreWrapper : PointWrapper
{
    public override void BonusSetter()
    {
        bonus = new BonusPoints();
    }
}
