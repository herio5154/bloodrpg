using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController charController;
    public float movementSpeed;
     void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if(GameM.playerMoving == true)
        {
            float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
            float vertInput = Input.GetAxis("Vertical") * movementSpeed;

            Vector3 forwardMovement = transform.forward * vertInput;
            Vector3 rightMovement = transform.right * horizInput;

            charController.SimpleMove(forwardMovement + rightMovement);
        }
    
    }
}
