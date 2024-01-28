using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDestroy : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		//Detect collision of the player with a CheeseBlock
		if (col.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
