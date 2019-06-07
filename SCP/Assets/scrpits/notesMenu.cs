using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notesMenu : MonoBehaviour
{
    public GameObject[] menus;
 
   
    public virtual void changeNotesMenu(int ID)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == ID);
        }
        gameObject.SetActive(false);
    }
}
