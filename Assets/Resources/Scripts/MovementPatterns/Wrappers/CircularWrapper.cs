using UnityEngine;

[CreateAssetMenu(menuName = "Movements/Circular")]
public class CircularWrapper : MovementWrapper
{
    public float sinAmp;
    public float cosAmp;
    public float sinSpeed;
    public float cosSpeed;

    public override void SetMovement()
    {
        movement = new Circular(sinAmp,cosAmp,sinSpeed,cosSpeed);
    }
}
