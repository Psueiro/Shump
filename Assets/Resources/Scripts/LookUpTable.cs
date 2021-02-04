using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1,T2>
{
    public delegate T2 FactoryMethod(T1 par);     
    Dictionary<T1,T2> table = new Dictionary<T1,T2>();
    FactoryMethod myFactory;

    public LookUpTable(FactoryMethod factory)
    {
        myFactory = factory;
    }

    public T2 ReturnValue(T1 par)
    {
        //Debug.Log(table.Count);
        if(!table.ContainsKey(par))
        {
            Debug.Log("Creo");
            var value = myFactory(par);
            table.Add(par, value);
            return value;
        }
        else
        {
            Debug.Log("Devuelvo");
            return table[par];
        }
    }
}
