using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoldingItems : MonoBehaviour, INtractable
{
    public Rigidbody rigidBody;
    private Vector3 lastPos = Vector3.zero, poseDela = Vector3.zero;
    private bool Holding;
 
    void Update()
    {
       if(Holding == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("hay");
            }
        }
      

    }


    public void PickUp(Transform Pos)
    {
        Holding = true;
        transform.position = Pos.position;
        transform.parent = Pos;
        rigidBody.useGravity = false;
     }
    public void Drop(float power)
    {
        Holding = false;
        transform.parent = null;
        rigidBody.useGravity = true;
        rigidBody.AddForce(Camera.main.transform.forward *power);
        GameM.playerMoving = true;
   
    }
   
}
