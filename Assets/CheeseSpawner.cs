using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cheeseBlockGo;
	[SerializeField] private GameObject spawnArea;
	[SerializeField] private float minX, maxX, minZ, maxZ;
	[SerializeField] private float noSpawnRadius;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			SpawnObject();
		}
	}


	void SpawnObject()
	{
		Vector3 spawnPosition;

		// Blijf proberen nieuwe co�rdinaten te genereren totdat deze buiten de noSpawnRadius liggen
		do
		{
			// Genereer willekeurige co�rdinaten binnen de opgegeven grenzen
			float randomX = Random.Range(minX, maxX);
			float randomZ = Random.Range(minZ, maxZ);

			// Cre�er een nieuwe positie met de willekeurige co�rdinaten en de huidige y-co�rdinaat
			spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

		} while (Vector3.Distance(spawnPosition, transform.position) < noSpawnRadius);

		// Spawn het object op de bepaalde positie
		Instantiate(cheeseBlockGo, spawnPosition, Quaternion.identity);
	}
}
