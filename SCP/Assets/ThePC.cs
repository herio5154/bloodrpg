using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePC : MonoBehaviour,IIntractable
{
    public GameObject thePC;

    public virtual void Use()
    {
        thePC.SetActive(true);
    }
    public void PickUp(Transform PlayerHands)
    {
       
    }
    public void Drop()
    {
    
    }
}
