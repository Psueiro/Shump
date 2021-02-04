using UnityEngine;

[CreateAssetMenu(menuName = "Movements/Straight")]
public class StraightWrapper : MovementWrapper
{
    public float speed;
    public Vector3 dir;

    public override void SetMovement()
    {
        movement = new Straight(speed, dir);
    }
}
