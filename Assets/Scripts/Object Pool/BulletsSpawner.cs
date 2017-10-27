using UnityEngine;

public class BulletsSpawner : MonoBehaviour
{
    public Bullet bulletPrefab;

    public int initialStock;

    public float cooldown;

    private float currentTime;

    private Pool<Bullet> _bulletPool;

    private static BulletsSpawner _instance;

    public static BulletsSpawner Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;

        _bulletPool = new Pool<Bullet>(initialStock,
                                       BulletFactory,
                                       bulletPrefab.InitializeObject,
                                       bulletPrefab.DiscardObject,
                                       true);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentTime >= cooldown)
        {
            _bulletPool.GetObjectFromPool();

            currentTime = 0;
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
