using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour,IIntractable
{
    public Transform[] openClosed;
    public bool isOpen;
    public GameObject Hinge;
    public void PickUp(Transform destnation)
    {
        isOpen = !isOpen;
        iTween.RotateTo(Hinge, iTween.Hash("rotation", openClosed[isOpen ? 0 : 1], "time", 3, "easetype", iTween.EaseType.spring));
     }
  public void Drop()
    {

    }
    public void Use()
    {
        isOpen = !isOpen;
        iTween.RotateTo(Hinge, iTween.Hash("rotation", openClosed[isOpen ? 0:1], "time", 3, "easetype", iTween.EaseType.spring));
        Debug.Log(isOpen ? 0 : 1);

    }

}
