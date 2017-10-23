using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float displacementForce;
    public float rotationSpeed;

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _rigidBody.AddForce(transform.forward * displacementForce);

        if (Input.GetKey(KeyCode.A))
            _rigidBody.AddForce(-transform.right * displacementForce);

        if (Input.GetKey(KeyCode.S))
            _rigidBody.AddForce(-transform.forward * displacementForce);

        if (Input.GetKey(KeyCode.D))
            _rigidBody.AddForce(transform.right * displacementForce);

        Plane _plane = new Plane(Vector3.up, transform.position);

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDistance = default(float);

        if (_plane.Raycast(_ray, out hitDistance))
        {
            Vector3 targetPoint = _ray.GetPoint(hitDistance);

            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
