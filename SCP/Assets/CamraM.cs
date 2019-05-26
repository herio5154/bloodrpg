using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraM : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject CellCam;
    public GameObject Hallcam;
     private void OnEnable()
    {
        CellCam.SetActive(false);
        Hallcam.SetActive(false);
        GameM.playerMoving = false;
        PlayerCam.SetActive(false);
    }

    public void HallcamCheck()
    {
        Debug.Log("i am on");
    }
    public void CellcamCheck()
    {
        Debug.Log("i am on");
       
    }
}
