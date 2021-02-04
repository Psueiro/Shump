using UnityEngine;
[CreateAssetMenu(menuName = "Patterns/Spiral")]
public class SpiralWrapper : PatternWrapper
{
    public int amount;

    public override void PatternSetter()
    {
        pattern = new Spiral(bullet, speed, amount);
    }
}
