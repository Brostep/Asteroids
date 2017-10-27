using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public int initialStock;

    public float spawnRate;

    private float currentTime;

    private Pool<Asteroid> _asteroidPool;

    private static AsteroidsSpawner _instance;

    public static AsteroidsSpawner Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;

        _asteroidPool = new Pool<Asteroid>(initialStock,
                                           AsteroidFactory,
                                           asteroidPrefab.InitializeObject,
                                           asteroidPrefab.DiscardObject,
                                           true);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnRate)
        {
            _asteroidPool.GetPoolObject();

            currentTime = 0;
        }
    }

    private Asteroid AsteroidFactory()
    {
        return Instantiate(asteroidPrefab);
    }

    public void ReturnAsteroidToPool(Asteroid asteroid)
    {
        _asteroidPool.DisablePoolObject(asteroid);
    }
}
