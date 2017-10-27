using UnityEngine;

public class Bullet : Projectile
{
    public enum BulletStrategies
    {
        Automatic,
        Laser,
        Bomb
    }

    public BulletStrategies bulletContext;

    public IShotBehaviour bulletStrategy;

    private void Awake()
    {
        switch (bulletContext)
        {
            case BulletStrategies.Automatic:
                bulletStrategy = new Automatic();
                break;

            case BulletStrategies.Laser:
                bulletStrategy = new Laser();
                break;

            case BulletStrategies.Bomb:
                bulletStrategy = new Bomb();
                break;
        }
    }

    public void AutomaticShot()
    {
        bulletStrategy.Shoot();
    }

    public override void Initialize()
    {
        transform.position = BulletsSpawner.Instance.transform.position;
        transform.rotation = BulletsSpawner.Instance.transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10) BulletsSpawner.Instance.ReturnBulletToPool(this);
    }
}
