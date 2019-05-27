using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamraPC : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject playerthing;
    public GameObject CellCam;
    public GameObject Hallcam;
    [Space]
    public CellDoorCard [] cellDoors;
    [Header("cell doors")]
 
    private bool wait;
    [System.Serializable]
    public class CellDoorCard
    {

        public Text Butotntext;
        public cellDoorControl cellDoor;
    }
    
     private void OnEnable()
    {
        playerthing.SetActive(false);
        CellCam.SetActive(false);
        Hallcam.SetActive(false);
        GameM.playerMoving = false;
        PlayerCam.SetActive(false);
    }
    public void FixedUpdate()
    {
        foreach (var C in cellDoors)
        {
            C.Butotntext.text = C.cellDoor.DoorText;
        }
    }
    public void DoorOpen(int ID)
    {
        if(cellDoors[ID].cellDoor.Loading == false)
        {
            cellDoors[ID].cellDoor.openDoor();
        }
    }
    public void HallcamCheck()
    {
        CellCam.SetActive(true);
        gameObject.SetActive(false);
    }
    public void CellcamCheck()
    {
        Debug.Log("i am on");
       
    }
    public void exitMenu()
    {
        GameM.playerMoving = true;
        PlayerCam.SetActive(true);
        gameObject.SetActive(false);
        playerthing.SetActive(true);

    }
    public string ButtonText(bool ISOpen)
    {
        string bace = "cell Door ";
        if (ISOpen == true) return bace + "open";
        else return bace + "Closed";
     
    }
   
}
