using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/Aim")]
public class AimWrapper : PatternWrapper
{
    public Vector3 target;
    public Vector3 target2;
    public bool isDynamic;

    public override void PatternSetter()
    {
        if(isDynamic)
        pattern = new Aim(bullet, speed, color).SetTarget(target2);
        else
        pattern = new Aim(bullet, speed, color).SetTarget(target);
    }

    public AimWrapper SetTarget(Vector3 t)
    {
        target2 = t;
        return this;
    }
}
