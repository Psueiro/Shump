using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner
{
    PoolUnit _myGeneric;
    string _path;
    Transform _transform;
    public Pool<PoolUnit> myGenericPool;

    public GenericSpawner(Transform t, Pool<PoolUnit> pool, string path)
    {
        _myGeneric = Resources.Load<PoolUnit>("Prefabs/" + path);
        _transform = t;
        myGenericPool = pool;
    }

    public PoolUnit GenericFactory()
    {
        return MonoBehaviour.Instantiate(_myGeneric);
    }

    public void ReturnGeneric(PoolUnit generic)
    {
        myGenericPool.ReturnObject(generic);
    }
}
