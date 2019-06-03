using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour,IIntractable
{
    public GameObject objetToTurnOn;

    public virtual void Use()
    {
        objetToTurnOn.SetActive(true);
    }
    public void PickUp(Transform PlayerHands)
    {
       
    }
    public void Drop()
    {
    
    }
}
