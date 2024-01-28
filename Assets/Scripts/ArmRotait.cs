using System.Collections;
using UnityEngine;

public class ArmRotait : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float rotationAmount = 90f;  // Amount of rotation in degrees
    public float moveSpeed = 5f;
    public float rotationPauseTime = 2f; // Time to pause after rotation in seconds
    
    Vector3 initialRotation;

    private bool isRotating = false;
    private float timeSinceLastRotation = 0f;
    private Quaternion startRotation;

    void Start()
    {
        // Store the initial rotation of the arm
        startRotation = transform.rotation;
        initialRotation = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        // Increment the time since the last rotation
        timeSinceLastRotation += Time.deltaTime;

        // Check if it's time to perform the rotation
        if (!isRotating && timeSinceLastRotation >= 10f) // Perform rotation every 1 minute
        {
            StartCoroutine(RotateArm());
        }

        // Check if the arm is currently rotating
        if (isRotating)
        {
            // Rotate the arm
            float rotationStep = rotationSpeed * Time.deltaTime;
            Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 0f, rotationAmount);

            // Apply the rotation directly to the Transform
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);

            // Debug: Print current rotation during each frame
            Debug.Log("Current Rotation: " + transform.rotation.eulerAngles.z);
        }
    }

    IEnumerator RotateArm()
    {
        // Set flag to indicate rotation is happening
        isRotating = true;

        // Reset the time since last rotation
        timeSinceLastRotation = 0f;

        // Rotate the arm
        float rotationStep = rotationSpeed * Time.deltaTime;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 0f, rotationAmount);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);
            yield return null;
        }

        // Pause for specified time
        yield return new WaitForSeconds(rotationPauseTime);

        // Reset flag to indicate rotation is complete
        isRotating = false;

        // Reset the rotation for the upward movement
        transform.rotation = startRotation;
    }
}
