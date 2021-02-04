using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/EnemyAttributes")]
public class EnemyAttributes : ScriptableObject
{
    public int health;
    public int pointAmount;
    public int sentinelAmount;
    public int power;

    public float maxCooldown;
    public float movementTimeToChange;

    public BasicEnemy myType;

    public PointWrapper bonus;

    public EnemyBehaviours behaviour;

    public EnemyAttributes(BasicEnemy b, int h)
    {
        myType = b;
        health = h;
    }

    public EnemyAttributes SetPointAmount(int i)
    {
        pointAmount = i;
        return this;
    }

    public EnemyAttributes BonusSetter(PointWrapper b)
    {
        bonus = b;
        return this;
    }

    public EnemyAttributes SetSentinelsAmount(int i)
    {
        sentinelAmount = i;
        return this;
    }

    public EnemyAttributes SetCooldown(float i)
    {
        maxCooldown = i;
        return this;
    }

    public EnemyAttributes MovementChangeTimeSetter(float f)
    {
        movementTimeToChange = f;
        return this;
    }

    public EnemyAttributes PowerSetter(int f)
    {
        power = f;
        return this;
    }

    public EnemyAttributes SetBehaviours(EnemyBehaviours b)
    {
        behaviour = b;
        return this;
    }

    public EnemyAttributes Clone()
    {
        EnemyAttributes newEnemy = new EnemyAttributes(myType, health).SetBehaviours(behaviour).SetPointAmount(pointAmount).BonusSetter(bonus).SetSentinelsAmount(sentinelAmount).SetCooldown(maxCooldown).MovementChangeTimeSetter(movementTimeToChange).PowerSetter(power);

        return newEnemy;
    }
}
