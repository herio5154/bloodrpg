using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuM : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameM gameM;
    public GameObject [] PauseMenus;
    public GameObject[] NoteMenu;
 
    public virtual void changeNotesMenu(int ID)
    {
        for (int i = 0; i < NoteMenu.Length; i++)
        {
            NoteMenu[i].SetActive(i == ID);
        }
     }


    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && IsPaused == false) Paused();



    }
    
    public void openMenu(int menuID)
    {
        Cursor.visible = true;
        for (int i = 0; i < PauseMenus.Length; i++)
        {
            PauseMenus[i].SetActive(i == menuID);

        }
    }
 
    public void ChangeSeen()
    {
        Debug.Log("fix me");
    }
    public void exit()
    {
        Application.Quit();
    }

    public void Paused()
    {
        openMenu(0);
        IsPaused = true;
        Time.timeScale = 0;
        gameM.playerStuff.playerReticle.SetActive(false);
     }
    public void contuneGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
        gameM.playerStuff.playerReticle.SetActive(true);
        openMenu(10);

    }

}
