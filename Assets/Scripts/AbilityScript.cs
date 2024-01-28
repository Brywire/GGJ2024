using System.Collections;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
	bool abilityCheck = false;
	bool abilityActivated = false;
	float abilityCooldown = 2f; // Cooldown duration in seconds
	float cooldownTimer = 0f;

	public GameObject abilityPrefab; // Reference to your ability prefab

	void OnTriggerEnter(Collider col)
	{
		// Detect collision of the player with a CheeseBlock to give it an ability.
		if (col.tag == "CheeseBlock" && !abilityActivated && cooldownTimer <= 0f)
		{
			abilityCheck = true;
		}
	}

	void Update()
	{
		// Check if the ability is activated and handle activation logic
		if (abilityCheck && !abilityActivated)
		{
			if (Input.GetKeyDown(KeyCode.E) && cooldownTimer <= 0f) 
			{
				ActivateAbility();
			}
		}

		// Update cooldown timer
		if (cooldownTimer > 0f)
		{
			cooldownTimer -= Time.deltaTime;
		}
	}

	void ActivateAbility()
	{
		// Instantiate the ability prefab or put your ability activation logic here
		Instantiate(abilityPrefab, transform.position, transform.rotation);

		// Set the abilityActivated flag to true to prevent multiple activations
		abilityActivated = true;

		// Start the cooldown timer
		cooldownTimer = abilityCooldown;

	
	}
}
