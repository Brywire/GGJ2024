using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float moveSpeed = 5f;
    public float acceleration = 10f; // Adjust this value for the desired acceleration

    public Transform orientation;
    Vector3 movement;
    public Rigidbody rb;

    void Update()
    {
        // Get input for movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        movement = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Move the player based on the input
    }

    void FixedUpdate()
    {
        Vector3 targetVelocity = movement.normalized * moveSpeed;

        // Smoothly interpolate between current velocity and target velocity
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime * acceleration);
    }
}
