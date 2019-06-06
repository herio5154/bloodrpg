using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithMenu : MonoBehaviour,IIntractable
{
    public GameObject objetToTurnOn;
    public GameM gameM;
    private bool wait;
    public virtual void Use()
    {
        turnON();
    }
    public void PickUp(Transform PlayerHands)
    {
     if(wait == false)
        {
            turnON();
        }
    }
    public void turnON()
    {
        gameM.turnOfAndOnPlayer(false);
        objetToTurnOn.SetActive(true);
    }
    public void Drop()
    {
        wait = true;
        gameM.turnOfAndOnPlayer(true);
        objetToTurnOn.SetActive(false);
        StartCoroutine(waitTouse());
    }
    IEnumerator waitTouse()
    { 
        yield return new WaitForSeconds(0.5f);
        wait = false;

    }
}
