using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeDoorM : MonoBehaviour,IIntractable

{
    public bool DoorON,wait;
    public GameObject Door;
    public Transform[] doorPos;
    public Transform[] buttonPos;
    public GameObject [] buttons;
    public AudioSource ButtonSource,DoorSource;
    public AudioClip DoorClickSound,DoorSound;
 
    public void Start()
    {
        buttons[0].transform.position = buttonPos[DoorON ? 1 : 0].position;
        buttons[1].transform.position = buttonPos[DoorON ? 3 : 2].position;

    }

    public  void PickUp(Transform destnation)
    {
         if(wait  == false && GameM.LockDown == false)
        {
            openDOor(DoorON = !DoorON);
            StartCoroutine(waitAseond());
        }
 
 
    }
    public void openDOor(bool Dooropen)
    {
        ButtonSource.PlayOneShot(DoorClickSound, 1f);
        DoorSource.PlayOneShot(DoorSound, 1f);
        wait = true;
        DoorON = Dooropen;
        iTween.MoveTo(Door, iTween.Hash("position", doorPos[DoorON ? 0 : 1], "time", 3f, "easetype", iTween.EaseType.easeInOutExpo));
        iTween.MoveTo(buttons[0], iTween.Hash("position", buttonPos[DoorON ? 1 : 0], "time", 0.5f, "easetype", iTween.EaseType.easeInOutBounce));
        iTween.MoveTo(buttons[1], iTween.Hash("position", buttonPos[DoorON ? 3 : 2], "time", 0.5f, "easetype", iTween.EaseType.easeInOutBounce));

    }
    public void Drop()
    {

    }
    public void Use()
    {

    }
    IEnumerator waitAseond()
    {
        yield return new WaitForSeconds(1);
        wait = false;
    }
}
