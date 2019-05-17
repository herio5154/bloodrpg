using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class HoldingItems : MonoBehaviour,IIntractable
{
    bool isHolding;
    private Transform hands;
    void Update()
    {
      //if(isHolding == true && GameM.playerMoving == true && Input.GetButtonDown("Fire2")) GameM.playerMoving = false;

  ///      if (isHolding == true && GameM.playerMoving == true && Input.GetButtonUp("Fire2")) GameM.playerMoving = false;
 
    }
    public void  Use()
    {

    }
    public void PickUp(Transform PlayerHands)
    {
        hands = PlayerHands;
         GetComponent<Rigidbody>().useGravity = false;
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
