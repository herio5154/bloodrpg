using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoldingItems : MonoBehaviour,IIntractable
{
    bool isHolding;

    void Update()
    {
  
    }
    public void  Use()
    {

    }
    public void PickUp(Transform PlayerHands)
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = PlayerHands.position;
        this.transform.parent = PlayerHands;
    }
    public void Drop()
    {
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.parent = null;
    }
}
