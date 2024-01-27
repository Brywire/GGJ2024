using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    private Vector3 curRotation;
    private Vector3 newRotation;

    [SerializeField]
    private float recoilX;
    [SerializeField]
    private float recoilY;
    [SerializeField]
    private float recoilZ;

    [SerializeField]
    private float smoothness;
    [SerializeField]
    private float returnSpeed;

    [SerializeField]
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        newRotation = Vector3.Lerp(newRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        curRotation = Vector3.Slerp(curRotation, newRotation, smoothness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(curRotation);

        if (Input.GetMouseButtonDown(0))
        {
            Shake();
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            Zoom();
        }
    }

    public void Shake()
    {
        newRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }

    public void Zoom() 
    {
        animator.Play("CameraZoom");
    }



}
