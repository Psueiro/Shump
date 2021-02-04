using UnityEngine;

public abstract class PatternWrapper : ScriptableObject
{
    public IBulletPatterns pattern;
    public Color color;
    public BasicBullet bullet;
    public float speed;
    public abstract void PatternSetter();
}
