using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/Circle")]
public class CircleWrapper : PatternWrapper
{
    public int amount;

    public override void PatternSetter()
    {
        pattern = new Circle(bullet, amount, speed, color);
    }
}
