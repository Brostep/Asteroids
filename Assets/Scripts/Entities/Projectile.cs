using UnityEngine;

public abstract class Projectile : MonoBehaviour, IPoolable<Projectile>
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    public void InitializeObject(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.Initialize();
    }

    public virtual void Initialize() { }

    public void DiscardObject(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
}
