using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public int initialStock;

    public float timeLapse;

    private float currentTime;

    private Pool<Asteroid> _asteroidPool;

    public Transform[] asteroidsSpawners;

    private static AsteroidsSpawner _instance;

    public static AsteroidsSpawner Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;

        _asteroidPool = new Pool<Asteroid>(initialStock, AsteroidFactory, Asteroid.InitializeAsteroid, Asteroid.InitializeAsteroid, true);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= timeLapse)
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
