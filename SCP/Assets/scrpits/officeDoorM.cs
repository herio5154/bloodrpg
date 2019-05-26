using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeDoorM : MonoBehaviour,IIntractable

{
    public bool DoorON,wait;
    public GameObject Door;
    public Transform[] doorPos;
    public AudioSource ButtonSource,DoorSource;
    public AudioClip DoorClickSound,DoorSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
