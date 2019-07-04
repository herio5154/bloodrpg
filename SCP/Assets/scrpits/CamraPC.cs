using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CamraPC : MonoBehaviour
{

    public GameObject CellCam;
    public GameObject Hallcam;
    public InteractWithMenu PC;
    [Space]
    public CellDoorCard [] cellDoors;
    [Header("cell doors")]
    public Color []TextClolor;
    private bool wait;
    [System.Serializable]
    public class CellDoorCard
    {

        public Text Butotntext;
        public cellDoorControl cellDoor;
    }
    
     private void OnEnable()
    {
         CellCam.SetActive(false);
        Hallcam.SetActive(false);
        GameM.playerMoving = false;
         foreach (var C in cellDoors)
        {
           
            C.Butotntext.color = TextClolor[CheckClour(C.Butotntext.text)];
            C.Butotntext.text = C.cellDoor.DoorText;
        }
    }
    public void FixedUpdate()
    {
        foreach (var C in cellDoors)
        {
            C.Butotntext.color = TextClolor[CheckClour(C.Butotntext.text)];
            C.Butotntext.text = C.cellDoor.DoorText;
        }
    }
    public void DoorOpen(int ID)
    {
        if(cellDoors[ID].cellDoor.Loading == false)
        {
            ////cellDoors[ID].cellDoor.openDoor();
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
        PC.Drop(); 
  
    }
    public int CheckClour(string State)
    {
        if (State.Contains("open")) return 0;
        if (State.Contains("Closed")) return 1;
        return 2;
    }
    public string ButtonText(bool ISOpen)
    {
        string bace = "cell Door ";
        if (ISOpen == true)
           return bace + "open";
        else return bace + "Closed";
     
    }
   
}
