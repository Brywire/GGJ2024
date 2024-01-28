using System.Collections;
using UnityEngine;

public class CatHand : MonoBehaviour
{
    public float hitInterval = 2f;      // Time between each hit
    public float hitForce = 10f;        // Force to apply when hitting the ground
    public float cooldownDuration = 2f; // Cooldown period after a successful hit
    public LayerMask hitLayer;          // Layer to detect for hitting the ground

    private float timer;
    private Collider handCollider;
    private bool canHit = true;

    void Start()
    {
        // Get the Collider component of the hand
        handCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (canHit)
        {
            timer += Time.deltaTime;

            // Check if it's time to hit the ground
            if (timer >= hitInterval)
            {
                HitGround();
                timer = 0f; // Reset the timer
            }
        }
    }

    void HitGround()
    {
        RaycastHit hit;

        // Cast a ray from the hand's position towards the mesh collider of the pizza slice
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, hitLayer))
        {
            // Check if the hit object has the "PizzaSlice" tag
            if (hit.collider.CompareTag("PizzaSlice"))
            {
                // Get the point of contact on the mesh
                Vector3 hitPoint = hit.point;

                // Apply force to the specific portion of the pizza slice
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
                if (hitRigidbody != null)
                {
                    hitRigidbody.AddForce(Vector3.down * hitForce);

                    // Disable the collider for a certain duration
                    StartCoroutine(DisableColliderForDuration(cooldownDuration));
                }
            }
        }
    }


    IEnumerator DisableColliderForDuration(float duration)
    {
        // Disable the collider
        handCollider.enabled = false;

        // Set canHit to false during the cooldown
        canHit = false;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Enable the collider again
        handCollider.enabled = true;

        // Allow the hand to hit again
        canHit = true;
    }
}
