using UnityEngine;

public abstract class PointWrapper : ScriptableObject
{
    public IBonus bonus;
    public abstract void BonusSetter();
}
