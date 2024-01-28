using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject spawn;

    Vector3 spawnPosition;
    Vector3 characterPosition;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = spawn.transform.position;
        characterPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       if( transform.position.y < -200)
        {
            transform.position = spawnPosition; 
            Debug.Log("Player respawned at: " + spawnPosition);
            Debug.Log("Current player position: " + transform.position);
        }
    }
}
