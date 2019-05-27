using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellDoorControl : MonoBehaviour
{
    public bool IsOpen,Loading;
    public GameObject Door;
    public Transform[] doorPos;
    public AudioSource  DoorSource;
    public AudioClip  DoorSound;
    public string DoorText;

    // Start is called before the first frame update
 
    public void openDoor()
    {
        IsOpen = !IsOpen;
        iTween.MoveTo(Door, iTween.Hash("position", doorPos[IsOpen ? 0 : 1], "time", 5, "easetype", iTween.EaseType.linear));
        DoorSource.PlayOneShot(DoorSound, 1f);
        DoorText = "Cell Loading";
        Loading = true;
        StartCoroutine(DoorLoading());
    }
    public string ButtonText()
    {
        string bace = "cell Door ";
        if (IsOpen == true) return bace + "open";
        else return bace + "Closed";

    }
    IEnumerator DoorLoading()
    {

        yield return new WaitForSeconds(6);
        DoorText = ButtonText();
        Loading = false;
    }
}
