using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular : IMovement
{
    Transform _t;
    Transform _target;
    float _sinSpeed;
    float _cosSpeed;
    float _sinAmp;
    float _cosAmp;

    public Circular(float sinAmp, float cosAmp, float sinSpeed, float cosSpeed)
    {
        _sinAmp = sinAmp;
        _cosAmp = cosAmp;
        _sinSpeed = sinSpeed;
        _cosSpeed = cosSpeed;
    }

    public void Movement()
    {
        _t.position += new Vector3(Mathf.Sin(Time.time * _sinSpeed) * _sinAmp, Mathf.Cos(Time.time * _cosSpeed) * _cosAmp) * Time.deltaTime;
    }

    public IMovement TransformAssigner(Transform t)
    {
        _t = t;
        return this;
    }

    public IMovement TargetAssigner(Transform t)
    {
        _target = t;
        return this;
    }
}
