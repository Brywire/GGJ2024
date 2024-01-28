using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    public GameObject mainCamera;
    CamaraMovement cameraMovementComponent;
    public GameObject rScreen;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text countdownDisplay;
    public Transform canvas;



    void Start()
    {
        timerIsRunning = true;

        // Access the CameraMovement script component on the mainCamera object
        cameraMovementComponent = mainCamera.GetComponent<CamaraMovement>();

    }


   

    void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                RedScreen(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Countdown timer has reached 0 seconds!");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownDisplay.text = string.Format("{1:00}", minutes, seconds);
    }

    void RedScreen(float timeToDisplay)
    {
        if (timeToDisplay <= 0)
        {
            float pause = 10f;

            // Instantiate the red screen prefab as a child of the Canvas
            GameObject redScreenInstance = Instantiate(rScreen, canvas);

            Debug.Log("The screen is red");
            

            // Using a coroutine to wait for a certain duration
            StartCoroutine(PauseBeforeDestroy(redScreenInstance, pause));
        }
    }

    // Coroutine to wait for a certain duration before destroying the red screen instance
    IEnumerator PauseBeforeDestroy(GameObject obj, float pauseDuration)
    {
        yield return new WaitForSeconds(pauseDuration);

        // Destroy the red screen instance after the pause duration
        Destroy(obj);

        timeRemaining = 10f;
        timerIsRunning = true;

    }
}
