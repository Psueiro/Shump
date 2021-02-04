using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinuous : IMovement
{
    Transform _t;
    float _frequencyX;
    float _frequencyY;
    float _amplitudeX;
    float _amplitudeY;

    LookUpTable<float, float> _sinTable;
    LookUpTable<float, float> _sinTableY;
    SinTableReference sinTRX = new SinTableReference();
    SinTableReference sinTRY = new SinTableReference();

    public Sinuous(float amplitudeX, float frequencyX, float amplitudeY, float frequencyY)
    {
        _sinTable = new LookUpTable<float, float>(MovementValue);
        _sinTableY = new LookUpTable<float, float>(MovementValueY);
        _amplitudeX = amplitudeX;
        _frequencyX = frequencyX;

        _amplitudeY = amplitudeY;
        _frequencyY = frequencyY;
    }

    float MovementValue(float s)
    {
        return Mathf.Sin(s * Mathf.PI * _frequencyX) * _amplitudeX * Time.deltaTime;
    }

    float MovementValueY(float s)
    {
        return Mathf.Sin(s * Mathf.PI * _frequencyY) * _amplitudeY * Time.deltaTime;
    }

    public void Movement()
    {
        sinTRX.a = _amplitudeX;
        sinTRX.f = _frequencyX;
        sinTRX.extra = _t.position.y;

        sinTRY.a = _amplitudeY;
        sinTRY.f = _frequencyY;

        sinTRX.dt = sinTRY.dt = Time.deltaTime;

        if(_amplitudeX == 0)
        { Debug.Log("Y");
            sinTRX.extra = _t.position.x;
            _t.position += new Vector3(0,_sinTableY.ReturnValue(_t.position.x));
        }
        else if(_amplitudeY == 0)        
        {
            Debug.Log("X");
            _t.position += new Vector3(Mathf.Sin(_t.position.y * Mathf.PI * _frequencyX) * _amplitudeX * Time.deltaTime,0);
        }else
        {        
            Debug.Log("Both");
            _t.position += new Vector3(_sinTable.ReturnValue(_t.position.y), _sinTableY.ReturnValue(_t.position.x));
        }
    }

    public IMovement TransformAssigner(Transform t)
    {
        _t = t;
        return this;
    }
}
