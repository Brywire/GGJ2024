using System.Collections;
using UnityEngine;

public class CatHand : MonoBehaviour
{
    public float hitInterval = 2f;  // Time between each hit
    public float hitForce = 10f;    // Force to apply when hitting the ground
    public LayerMask hitLayer;      // Layer to detect for hitting the ground

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to hit the ground
        if (timer >= hitInterval)
        {
            HitGround();
            timer = 0f; // Reset the timer
        }
    }

    void HitGround()
    {
        // Raycast to check if there's something to hit
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, hitLayer))
        {
            // Apply force to the object hit
            Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
            if (hitRigidbody != null)
            {
                hitRigidbody.AddForce(Vector3.down * hitForce, ForceMode.Impulse);

                // Disable the collider of the ground
                Collider groundCollider = hit.collider.GetComponent<Collider>();
                if (groundCollider != null)
                {
                    // Option 1: Disable the collider (recommended if you might re-enable it later)
                    groundCollider.enabled = false;

                    // Option 2: Destroy the collider (use with caution, cannot be undone)
                    // Destroy(groundCollider);
                }
            }
        }
    }
}
