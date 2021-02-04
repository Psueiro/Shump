using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : IBomb
{
    Bomb _bomb;

    public void Bomb(Vector3 v)
    {
        _bomb.transform.position = v;
    }

    public IBomb Reset()
    {
        _bomb.transform.localScale = new Vector3(15,15,1);
        return this;
    }

    public void Effect()
    {
        _bomb.transform.localScale += new Vector3(1,1,0) * 30 * Time.deltaTime;
    }

    public IBomb BombModelSetter(Bomb b)
    {
        _bomb = b;
         return this;
    }
}
