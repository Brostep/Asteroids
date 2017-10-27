using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody _rigidBody;

    public Boundary boundary;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);

        _rigidBody.velocity = movement * movementSpeed;
        _rigidBody.position = new Vector3(Mathf.Clamp(_rigidBody.position.x, boundary.xMin, boundary.xMax), 0,
                                          Mathf.Clamp(_rigidBody.position.z, boundary.zMin, boundary.zMax));

        Plane _plane = new Plane(Vector3.up, transform.position);

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDistance = 0;

        if (_plane.Raycast(_ray, out hitDistance))
        {
            Vector3 targetPoint = _ray.GetPoint(hitDistance);

            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
