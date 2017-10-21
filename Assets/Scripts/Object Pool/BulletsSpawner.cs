using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    public Bullet bulletPrefab;

    public int initialStock;

    public float cooldown;

    private float currentTime;

    private Pool<Bullet> _bulletPool;

    private static BulletsSpawner _instance;

    public static BulletsSpawner Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;

        _bulletPool = new Pool<Bullet>(initialStock, BulletFactory, Bullet.InitializeBullet, Bullet.DisposeBullet, true);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentTime >= cooldown)
        {
            _bulletPool.GetObjectFromPool();

            currentTime = default(float);
        }
    }

    private Bullet BulletFactory()
    {
        return Instantiate(bulletPrefab);
    }

    public void ReturnBulletToPool(Bullet bullet)
    {
        _bulletPool.DisablePoolObject(bullet);
    }
}
