using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float platformSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Ensures smooth movement
    }

    void FixedUpdate() // Use FixedUpdate for physics movement
    {
        transform.position -= Vector3.back * platformSpeed * Time.fixedDeltaTime;
    }
}
