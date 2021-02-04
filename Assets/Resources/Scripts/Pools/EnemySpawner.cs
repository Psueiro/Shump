using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public App app;
    public BasicEnemy enemy;
    public BasicEnemy bigEnemy;
    public EnemyAttributes sentinel;
    public Pool<BasicEnemy> basicEnemyPool;

    void Start()
    {
        basicEnemyPool = new Pool<BasicEnemy>(BasicEnemyFactory,BasicEnemy.TurnOn,BasicEnemy.TurnOff, 20);
    }

    BasicEnemy BasicEnemyFactory()
    {
        return Instantiate(enemy).SetSpawner(this).SetHero(app.model).SetBulletSpawner(app.bulletSpawner).SetPointSpawner(app.pointSpawner).SetParent(transform);
    }

    public void ReturnEnemy(BasicEnemy e)
    {
        basicEnemyPool.ReturnObject(e);
    }
}
