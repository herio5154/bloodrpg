using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArciveBox : DragObjet
{
    public GameObject Stuff,lid,Box,lidUnder;
   public bool canUse;
 
    public Transform  moveToo;
 
     // Start is called before the first frame update
    void Start()
    {
        Stuff.SetActive(false);
        lidUnder.SetActive(false);
     }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("sup");
        canUse =  true;
       
    }
   
    
    public override void Use()
    {
        if(canUse == true)
        {
            iTween.MoveTo(lid, iTween.Hash("position",moveToo, "time", 1f, "easetype", iTween.EaseType.spring));
            Invoke("OpenBox", 1);
            Box.transform.parent = null;
            canUse = false;

        }


    }
    public override void PickUp(Transform PlayerHands)
    {
     if(canUse == false)
        {
            base.PickUp(PlayerHands);
        }
    }
    public void OpenBox()
    {
        Stuff.SetActive(true);
        lid.SetActive(false);
        lidUnder.SetActive(true);
        Destroy(gameObject);
    }
    
}
