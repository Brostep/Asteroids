using UnityEngine;

public class Asteroid : Projectile
{
    public override void Initialize()
    {
        transform.position = AsteroidsSpawner.Instance.transform.position;
        transform.rotation = AsteroidsSpawner.Instance.transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9) AsteroidsSpawner.Instance.ReturnAsteroidToPool(this);
    }
}
