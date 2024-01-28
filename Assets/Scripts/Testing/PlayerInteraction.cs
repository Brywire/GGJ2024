using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rotationSpeedMultiplier = 1f; // Adjust the multiplier as needed

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheeseWheel"))
        {
            // Get the CheeseWheel script and increase the rotation speed
            TestWheeling cheeseWheel = other.GetComponent<TestWheeling>();
            if (cheeseWheel != null)
            {
                cheeseWheel.IncreaseRotationSpeed(rotationSpeedMultiplier);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CheeseWheel"))
        {
            // Optionally, reset the rotation speed or perform other actions when leaving the wheel
        }
    }
}
