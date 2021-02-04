using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBomb
{
    void Bomb(Vector3 v);
    void Effect();
    IBomb Reset();
    IBomb BombModelSetter(Bomb h);
}
