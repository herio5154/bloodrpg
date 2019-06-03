using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camraM : MonoBehaviour
{
    public CamInfoCard [] camInfo;
    public Text camText;
    private int camID;
    public GameObject menu;
    [System.Serializable]
    public class CamInfoCard
    {
        public string camName;
        public GameObject Camra;
        public Light CamLight;
    }
    public void OnEnable()
    {
        changeCamra(0);
    }
    public void changeCamra(int NewcamID)
    {

        camText.text = camInfo[NewcamID].camName;
        camInfo[camID].Camra.SetActive(false);
        camInfo[NewcamID].Camra.SetActive(true);
        camID = NewcamID;
    }
    public void back()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);

    }
}
