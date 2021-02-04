using System.Collections;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public App app;
    EnemySpawner _spawner;
    BulletSpawner _bulSpawner;
    public EnemyAttributes[] enemies;
    public Vector3[] enemyLocations;
    public float[] nextSpawnCooldown;

    void Start()
    {
        _spawner = app.enemySpawner;
        _bulSpawner = app.bulletSpawner;

        StartCoroutine(FirstWaveCall(2));
    }

    IEnumerator FirstWaveCall(float timer)
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(WaveCaller(0));
    }

    IEnumerator WaveCaller(int i)
    {
        SpawnEnemy(enemies[i], enemyLocations[i]);
        yield return new WaitForSeconds(nextSpawnCooldown[i]);
        if (i + 1 < enemies.Length)
            StartCoroutine(WaveCaller(i + 1)); else EventManager.TriggerEvent("Win");
    }

    void SpawnEnemy(EnemyAttributes e, Vector3 l)
    {
        e.bonus.BonusSetter();
        BasicEnemy basicEnemy = _spawner.basicEnemyPool.GetObject();
        basicEnemy.UnitDefiner(e.myType);
        basicEnemy.SetPowerAmount(e.power).SetHealth(e.health).SetCooldown(e.maxCooldown).SetSpawner(_spawner).SetSetinelAmount(e.sentinelAmount).BonusSetter(e.bonus.bonus).SetPointAmount(e.pointAmount).SetLocation(l);
        basicEnemy.movementOptions.Clear();
        basicEnemy.behaviour = e.behaviour.Clone();
        basicEnemy.behaviour.TargetSetter(basicEnemy._model.transform.position);

        if (e.sentinelAmount > 0)
        {
            basicEnemy.SentinelSpawn();
        }

        if (e.behaviour.changeMovementWrappers.Length > 0)
        {
            basicEnemy.StartCoroutine(basicEnemy.ChangeMovement(e.movementTimeToChange, e.behaviour.changeMovementWrappers));
        }
    }
}
