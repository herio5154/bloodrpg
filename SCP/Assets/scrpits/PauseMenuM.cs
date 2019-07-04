using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuM : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameM gameM;
    public GameObject [] PauseMenus;
    public GameObject[] NoteMenu;
    public AudioSource playerAudio;
    public bool SoundPasue;
    public void Start()
    {
 

    }
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
        if (playerAudio.isPlaying == true)
        {
            playerAudio.Pause();
            SoundPasue = true;
        }

 
        Cursor.visible = true;
        openMenu(0);
        IsPaused = true;
        Time.timeScale = 0;
        gameM.playerStuff.playerReticle.SetActive(false);
     }
    public void contuneGame()
    {
        if(SoundPasue == true)
        {
            playerAudio.Play();
            SoundPasue = false;
        }
        IsPaused = false;
        Time.timeScale = 1;
        gameM.playerStuff.playerReticle.SetActive(true);
        openMenu(10);

    }

}
