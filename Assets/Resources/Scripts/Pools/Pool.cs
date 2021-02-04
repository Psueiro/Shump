using System.Collections.Generic;

public class Pool<T>
{
    public delegate T FactoryMethod();
    public delegate void Callback(T pool);

    public FactoryMethod _factoryMethod;
    public int _initialStock;
    public List<T> _currentStock;

    Callback _turnOnCallback;
    Callback _turnOffCallback;

    public Pool(FactoryMethod factoryMethod, Callback turnOnCallback, Callback turnOffCallback, int initialStock)
    {
        _factoryMethod = factoryMethod;
        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;
        _initialStock = initialStock;

        _currentStock = new List<T>();

        for (int i = 0; i < initialStock; i++)
        {
            var objPool = _factoryMethod();
            _turnOffCallback(objPool);//
            _currentStock.Add(objPool);
        }
    }

    public T GetObject()
    {
        var result = default(T);
        if (_currentStock.Count > 0)
        {
            result = _currentStock[0];
            _currentStock.Remove(result);
        }else
         result = _factoryMethod();

        _turnOnCallback(result);
        return result;
    }

    public void ReturnObject(T objPool)
    {
        _turnOffCallback(objPool);
        _currentStock.Add(objPool);
    }
}
