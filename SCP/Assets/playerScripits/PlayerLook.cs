using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

   public float mouseSensitivity;
    public Transform playerBody;
    [Space]
    public float range = 100f;
    private float xAxisClamp;
    public  Camera PlayerCam;
    public LayerMask intractableLayer;
    public Transform hands;
    private bool ISholding;
    public INtractable InHands;
    public float throwForce = 5f;
     // Start is called before the first frame update
    void Start()
    {
        PlayerCam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(ISholding == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
            InHands.Drop(throwForce);
                ISholding = false;
           }
          
        }
        if (ISholding == false)
        {
 
            if (Input.GetButtonDown("Fire1")) Act();

        }
     if(GameM.playerMoving == true)CameraRotation();
   
    
    }
    private void Act()
    {
        RaycastHit Hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range, intractableLayer))
        {
            Debug.Log("hit" + Hit.transform.tag);
            if (Hit.transform.tag == "Intractable")
            {
                Debug.Log("hit");
                Hit.transform.GetComponent<INtractable>().PickUp(hands);
                InHands = Hit.transform.GetComponent<INtractable>();
                ISholding = true;
            }
        }
    }
     
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
