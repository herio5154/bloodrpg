using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuM : MonoBehaviour
{
    public GameObject[] menus;
    public int couter;
    public Text Header;
    public Text infoText;
    public GameM GameM;
    public Text[] buttonText;
    public GameObject[] buttons;
    public int  colectableID;
    public colectableM [] colecTables;
    public virtual void OnEnable()
    {
        couter = 0;
        changeMenu(0);
    }
    public void changeMenu(int menuID)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == menuID);
        }
    }
    public virtual void perfromAction(int ID)
    {
        Debug.Log("colectable");
    }
}
