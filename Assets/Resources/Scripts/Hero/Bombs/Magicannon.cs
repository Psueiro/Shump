using UnityEngine;

public class Magicannon : IBomb
{
    Bomb _bomb;

    public IBomb BombModelSetter(Bomb b)
    {
        _bomb = b;
        return this;
    }

    public void Bomb(Vector3 v)
    {
        _bomb.transform.position = v + new Vector3(0,10,0);
    }

    public void Effect()
    {
        _bomb.transform.localScale += new Vector3(40, 0, 0) * Time.deltaTime;
    }

    public IBomb Reset()
    {
        _bomb.transform.localScale = new Vector3(1, 120, 1);
        return this;
    }
}
