using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocobarSpawn : MonoBehaviour
{

    bool Ifhit = false;
    bool Ifhit2 = false;
    // Define the force to shoot the player away
    public float m_Thrust = 9999f;
    public Rigidbody Player1;
    public Rigidbody Player2;
    public Transform chocobar;
    private void Start()
    {
       
    }
    // Called when the Collider on this object enters another Collider
    void OnTriggerStay(Collider col)
    {
        // Check if the other object has the "Player" tag
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Moi em");        
            Ifhit= true;
        }
        if (col.gameObject.tag == "Player2")
        {
            Debug.Log("Moi em");
            Ifhit2 = true;
        }
    }

    private void Update()
    {
        if (Ifhit == true) 
        {
            Player1.AddForce(chocobar.forward * m_Thrust, ForceMode.Impulse);
        }
        if (Ifhit2 == true)
        {
            Player2.AddForce(chocobar.forward * m_Thrust, ForceMode.Impulse);
        }
    }
}
