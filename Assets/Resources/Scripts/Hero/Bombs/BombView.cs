using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombView 
{
    Bomb _bomb;

    public BombView(Bomb bomb)
    {
        _bomb = bomb;
        _bomb.BombFX += BombEffect;
    }

    void BombEffect()
    {
        _bomb.myBomb.Reset();
        _bomb.myBomb.Bomb(_bomb.transform.position);
    }
}
