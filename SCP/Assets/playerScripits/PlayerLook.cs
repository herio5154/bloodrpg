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
    public Transform playerHands;
    public bool ISholding;
    private IIntractable holding;
    public LayerMask layerMask;
    [Space]
    [Header("zoom")]
    public float camZoom = 60;
    public float camDis, minZooom;
    public float changeAmount;
    private bool Iszoom;
     public static bool lockCamra;
      // Start is called before the first frame update
    void Start()
    {
        PlayerCam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame

    void Update()
    {

        if(GameM.playerMoving == true)
        {
            if (Input.GetButtonUp("Fire2") && ISholding == false)
            {
                RaycastHit Hit;
                if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range,layerMask))
                {

                    if (Hit.transform.tag == "Intractable")
                    {
                        Hit.transform.GetComponent<IIntractable>().Use();
                    }

                }
            }

                if (Input.GetButtonDown("Fire1")&&ISholding ==false)
            {
             
           
                RaycastHit Hit;
                if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range,layerMask))
                {

                    if (Hit.transform.tag == "Intractable")
                    {
                         Hit.transform.GetComponent<IIntractable>().PickUp(playerHands);
                        ISholding = true;
                        holding = GetComponent<IIntractable>();
                    }
                   
                }
            }
            if(Input.GetButtonUp("Fire1") && ISholding == true)
             {
               
                RaycastHit Hit;
                if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range, layerMask))
                {

                    if (Hit.transform.tag == "Intractable")
                    {
                        Hit.transform.GetComponent<IIntractable>().Drop();
                     }
                  
                }
                if (playerHands.childCount > 0)
                {
                    Transform hands = playerHands.transform.GetChild(0);
                    hands.GetComponent<IIntractable>().Drop();
                }
                ISholding = false;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                Iszoom = false;
                if (camZoom > minZooom) camZoom -= changeAmount;
                PlayerCam.fieldOfView = camZoom;
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                StartCoroutine(Zoomout());
            }
          if(lockCamra == false)CameraRotation();
        }
           
    }
  private void use()
    {
        
        RaycastHit Hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range))
        {
               if (Hit.transform.tag == "Object" || Hit.transform.tag == "Intractable") Hit.transform.GetComponent<IIntractable>().Use();


        }
    }
   

       private void Act()
    {
 
         RaycastHit Hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out Hit, range))
        {
                 if (ISholding == false)
                {
                    if (Hit.transform.tag == "Intractable")
                   {

                    holding = Hit.transform.GetComponent<IIntractable>();
                    holding.Use();
                    }
                    if (Hit.transform.tag == "Object")
                    {
                    holding = Hit.transform.GetComponent<IIntractable>();
                    holding.PickUp(playerHands);
                    ISholding = true;
                    }
                    return;
                }
                if (ISholding == true)
                {
                    if (holding != null &&(Hit.transform.tag == "Object" || Hit.transform.tag == "Intractable"))
                    {
                    holding.Drop();
                    holding = null;
                    ISholding = false;
                    }
                    return;
                }
          


            
           
          ///  if (Hit.transform.tag == "Object" || Hit.transform.tag == "Intractable")  Hit.transform.GetComponent<IIntractable>().Use();

            

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
    IEnumerator Zoomout()
    {
        Iszoom = true;
        while (camZoom < camDis&&Iszoom == true)
        {
            camZoom += 1;
            PlayerCam.fieldOfView = camZoom;
            yield return new WaitForSeconds(0.01f);
        }
 
    }
   
}
