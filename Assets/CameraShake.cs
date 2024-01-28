using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject mainCamera;
    CamaraMovement cameraMovementComponent;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovementComponent = mainCamera.GetComponent<CamaraMovement>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PizzaSlice"))
        {
            cameraMovementComponent.Shake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
