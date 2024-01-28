using UnityEngine;

public class TestWheeling : MonoBehaviour
{
    public float initialRotationSpeed = 50f;
    private float currentRotationSpeed;

    void Start()
    {
        currentRotationSpeed = initialRotationSpeed;
    }

    void Update()
    {
        // Rotate the cheese wheel
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
    }

    public void IncreaseRotationSpeed(float amount)
    {
        currentRotationSpeed += amount;
    }
}
