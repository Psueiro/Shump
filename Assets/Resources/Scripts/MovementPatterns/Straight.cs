using UnityEngine;

public class Straight : IMovement
{
    Transform _t;
    public float speed;
    Vector3 _dir;

    public Straight(float s, Vector3 dir)
    {  
        speed = s;
        _dir = dir;
    }

    public IMovement DirSetter (Vector3 dir)
    {
        _dir = dir;
        return this;
    }

    public IMovement TransformAssigner(Transform t)
    {
        _t = t;
        return this;
    }

    public void Movement()
    {
        _t.transform.position += _dir * speed * Time.deltaTime;
    }
}
