using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class HoldingItems : MonoBehaviour,IIntractable
{
    bool isHolding;
    private Rigidbody rigidBody;
    private Transform hands;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
       if(isHolding == true && GameM.playerMoving == true && Input.GetButtonDown("Fire2")) GameM.playerMoving = false;
        if (isHolding == true && GameM.playerMoving == false && Input.GetButtonUp("Fire2")) GameM.playerMoving = true;
        if(isHolding == true && GameM.playerMoving == true)
        {
            this.transform.position = hands.position;
            rigidBody.velocity = Vector3.zero;

        }
    }
    public void  Use()
    {
 
    }
    public void PickUp(Transform PlayerHands)
    {
        hands = PlayerHands;
         rigidBody.useGravity = false;
         rigidBody.velocity = Vector3.zero;
         this.transform.position = PlayerHands.position;
        this.transform.parent = PlayerHands;
        isHolding = true;
    }
    public void Drop()
    {
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = null;
        isHolding = false;

    }
}
