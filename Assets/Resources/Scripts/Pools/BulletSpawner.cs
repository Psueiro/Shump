using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BasicBullet bullet;
    public BasicBullet bigBullet;
    public Pool<BasicBullet> bulletPool;

    public App app;

    private void Start()
    {
        bulletPool = new Pool<BasicBullet>(BulletFactory,BasicBullet.TurnOn,BasicBullet.TurnOff,30);
    }

    BasicBullet BulletFactory()
    {
        return Instantiate(bullet).SetHero(app.model).SetSpawner(this).SetParent(transform.GetChild(0));
    }

    public void ReturnBullet(BasicBullet b)
    {
        bulletPool.ReturnObject(b);
    }
}
