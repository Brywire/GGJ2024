using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		//Detect collision of the player bullet with an enemy ship
		if (col.tag == "CheeseBlock")
		{
			ChooseAbility();
		}


	}

	public void ChooseAbility()
	{
		//Choose between random abilities
	}
	public enum Abilities
	{
		Ability1,
		Ability2

	}
}
