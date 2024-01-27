using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWheeling : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Get the current rotation of the object
        Vector3 currentRotation = transform.eulerAngles;

        // Update the rotation by adding a rotation speed
        float newRotation = currentRotation.y + rotationSpeed * Time.deltaTime;

        // Apply the new rotation
        transform.eulerAngles = new Vector3(currentRotation.x, newRotation, currentRotation.z);
    }
}
