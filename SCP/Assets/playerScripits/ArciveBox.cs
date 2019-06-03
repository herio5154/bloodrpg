using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArciveBox : DragObjet
{
    public GameObject Stuff,lid,Box,lidUnder;
   public bool isopen,Wait;
  
    public Transform  [] moveToo;
 
     // Start is called before the first frame update
    void Start()
    {
        Stuff.SetActive(false);
        lidUnder.SetActive(false);
     }
    
    
    public override void Use()
    {
        if (Wait == false)
        {

            if (isopen == false)
            {
                iTween.MoveTo(lid, iTween.Hash("position", moveToo[0], "time", 1f, "easetype", iTween.EaseType.spring));
                Invoke("OpenBox", 1);


            }
            if (isopen == true)
            {
                iTween.MoveTo(lid, iTween.Hash("position", moveToo[1], "time", 1f, "easetype", iTween.EaseType.spring));
                Stuff.SetActive(false);
                lidUnder.SetActive(false);
                lid.SetActive(true);
                Invoke("closeBox", 1);

            }
            isopen = !isopen;
            Wait = true;

        }


    }
    public override void PickUp(Transform PlayerHands)
    {
     if(isopen == false)
        {
            base.PickUp(PlayerHands);
        }
    }
    public void closeBox()
    {
        Wait = false;
    }
    public void OpenBox()
    {
        Stuff.SetActive(true);
        lid.SetActive(false);
        lidUnder.SetActive(true);
        Wait = false;
    }

}
