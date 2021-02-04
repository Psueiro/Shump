using UnityEngine;
[CreateAssetMenu(menuName = "Patterns/Spray")]
public class SprayWrapper : PatternWrapper
{
    public float minRotation;
    public float maxRotation;

    public override void PatternSetter()
    {
        pattern = new SprayAndPray(bullet, speed,minRotation,maxRotation, color);
    }
}
