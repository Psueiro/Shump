using UnityEngine;

public interface IMovement
{
    void Movement();

    IMovement TransformAssigner(Transform t);
}
