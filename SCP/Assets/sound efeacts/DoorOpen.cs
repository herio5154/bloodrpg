using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour,IIntractable
{
    public Transform[] openClosed;
    public bool isOpen;
    public GameObject Hinge;
    public float OpenTime = 1f;
    public iTween.EaseType opentipe = iTween.EaseType.easeInExpo;
    public bool autoClose;
    public void Start()
    {
     }
    public void PickUp(Transform destnation)
    {
        Debug.Log("nope");

               openCloseDoor();
    }
    public void Drop()
    {

    }
    public void Use()
    {
        Debug.Log("nope");
        openCloseDoor();
    }
    public void openCloseDoor()
    {
        isOpen = !isOpen;
        iTween.RotateTo(Hinge, iTween.Hash("rotation", openClosed[isOpen ? 0 : 1], "time", OpenTime, "easetype", opentipe));
        Debug.Log(isOpen ? 0 : 1);
        if (autoClose == true && isOpen == true) Invoke("openCloseDoor", OpenTime+1);

    }

}
