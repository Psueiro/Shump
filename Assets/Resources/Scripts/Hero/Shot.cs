using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : PoolUnit
{
    public Model spawner;
    public float damage;
    bool _impervious;
    bool _aboutToDie;

    private void Start()
    {
        damage = spawner.damage;
    }

    private void Update()
    {
        for (int i = 0; i < movementOptions.Count; i++)
        {
            movementOptions[i].Movement();
        }
    }

    public IEnumerator ReturnTimer(float f)
    {
        _aboutToDie = true;
        yield return new WaitForSeconds(f);
        spawner.ReturnShot(this);
    }

    public Shot SetParent(Transform p)
    {
        transform.parent = p.transform;
        return this;
    }

    public Shot SetShotType(IMovement b)
    {
        if(!movementOptions.Contains(b))movementOptions.Add(b);
        return this;
    }

    public Shot SetImperviousness(bool b)
    {
        _aboutToDie = false;
        _impervious = b;
        return this;
    }

    public Transform FindTarget()
    {
        if (FindObjectOfType<BasicEnemy>())
            return FindObjectOfType<BasicEnemy>().transform;
        else return null;
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.layer == 8)
        {
            c.GetComponent<BasicEnemy>().TakeDamage(damage);
            if(!_impervious)
            spawner.ReturnShot(this);
        }

        if(c.gameObject.layer == 11 && _aboutToDie == false)
        {
            spawner.ReturnShot(this);
        }
    }
}
