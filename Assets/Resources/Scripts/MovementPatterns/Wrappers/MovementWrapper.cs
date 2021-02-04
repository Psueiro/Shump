using UnityEngine;

public abstract class MovementWrapper : ScriptableObject
{
    public IMovement movement;
    public abstract void SetMovement();
}
