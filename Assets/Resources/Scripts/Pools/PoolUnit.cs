using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolUnit : MonoBehaviour
{
    public List<IMovement> movementOptions = new List<IMovement>();
    public IMovement current;
    public BoxCollider2D boxC;
    public SpriteRenderer spr;

    // desde el principio de la cursada que te lo hago recordar :^)
    public static void TurnOn(PoolUnit s)
    {
        s.gameObject.SetActive(true);
    }

    public static void TurnOff(PoolUnit s)
    {
        s.gameObject.SetActive(false);
    }

    public PoolUnit AddMovement (IMovement b)
    {
        if (!movementOptions.Contains(b)) movementOptions.Add(b);
        return this;
    }

    public PoolUnit SetMovement(IMovement b)
    {
        current = b;
        return this;
    }

    public PoolUnit SetLocation(Vector3 v)
    {
        transform.position = v;
        return this;
    }

    public PoolUnit SetRotation(float f)
    {
        transform.rotation = Quaternion.Euler(0, 0, f);
        return this;
    }

    public PoolUnit UnitDefiner(PoolUnit p)
    {
        SpriteRenderer mSpr = p.GetComponent<SpriteRenderer>();
        if (!spr) spr = GetComponent<SpriteRenderer>();
        spr.drawMode = mSpr.drawMode;
        transform.localScale = p.transform.localScale;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        spr.sortingOrder = mSpr.sortingOrder;

        if (!boxC) boxC = GetComponent<BoxCollider2D>();
        BoxCollider2D mBoxC = p.GetComponent<BoxCollider2D>();
        boxC.size = mBoxC.size;
        boxC.offset = mBoxC.offset;
        spr.size = mSpr.size;
        spr.sprite = mSpr.sprite;
        spr.color = mSpr.color;
        return this;
    }
}
