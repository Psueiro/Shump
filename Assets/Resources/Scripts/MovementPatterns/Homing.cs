using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : IMovement
{
    Transform _t;
    Transform _target;
    float _speed;

    public Homing(float s)
    {
        _speed = s;
    }

    public void Movement()
    {
        _t.transform.up = -(_target.transform.position - _t.transform.position).normalized;
        _t.transform.position += (_target.transform.position - _t.transform.position).normalized * _speed * Time.deltaTime;
    }

    public IMovement TargetSetter(Transform t)
    {
        _target = t;
        return this;
    }

    public IMovement TransformAssigner(Transform t)
    {
        _t = t;
        return this;
    }
}
