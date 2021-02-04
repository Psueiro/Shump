using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/EnemyBehaviours")]
public class EnemyBehaviours : ScriptableObject
{
    public List<IBulletPatterns> allPatterns = new List<IBulletPatterns>();
    public List<IMovement> movementOptions = new List<IMovement>();
    public List<IMovement> changeOptions = new List<IMovement>();
    public MovementWrapper[] movementWrappers;
    public PatternWrapper[] patternWrappers;
    public MovementWrapper[] changeMovementWrappers;
    Vector3 _target;

    public EnemyBehaviours AddMovement(IMovement m)
    {
        movementOptions.Add(m);
        return this;
    }

    public EnemyBehaviours AddPattern(IBulletPatterns b)
    {
        allPatterns.Add(b);
        return this;
    }

    public EnemyBehaviours AddMovementChange(IMovement m)
    {
        changeOptions.Add(m);
        return this;
    }

    public EnemyBehaviours TargetSetter(Vector3 t)
    {
        _target = t;
        for (int i = 0; i < patternWrappers.Length; i++)
        {
            if (patternWrappers[i] is AimWrapper)
            {
                var test = patternWrappers[i] as AimWrapper;
                test.SetTarget(_target);
                patternWrappers[i] = test;
            }
        }
        return this;
    }

    public EnemyBehaviours Clone()
    {
        EnemyBehaviours newClone;
        newClone = CreateInstance<EnemyBehaviours>();
        newClone.movementWrappers = movementWrappers;
        for (int i = 0; i < newClone.movementWrappers.Length; i++)
        {
            newClone.movementWrappers[i].SetMovement();
            newClone.AddMovement(newClone.movementWrappers[i].movement);
        }

        newClone.patternWrappers = patternWrappers;
        for (int i = 0; i < newClone.patternWrappers.Length; i++)
        {
            newClone.patternWrappers[i].PatternSetter();           
            newClone.AddPattern(newClone.patternWrappers[i].pattern);
        }

        newClone.changeMovementWrappers = changeMovementWrappers;
        for (int i = 0; i < newClone.changeMovementWrappers.Length; i++)
        {
            newClone.changeMovementWrappers[i].SetMovement();
            newClone.AddMovementChange(newClone.changeMovementWrappers[i].movement);
        }
        return newClone;
    }
}
