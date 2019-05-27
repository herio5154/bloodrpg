using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emergencyButton : MonoBehaviour, IIntractable
{
    public GameM gameM;
    public bool IsOn;
    public GameObject Button;
    public Transform[] buttons;
    public AudioSource ButtonSource;
    public AudioSource [] WindowSource;
    public AudioClip buttonClickSound,DoorSound;
    public GameObject[] Windows;
    public Transform [] WindosTransfrom;
    public officeDoorM[] doorM;
    public GameObject [] Warninglight;
    void Start()
    {
        Warninglight[1].SetActive(false);
        Warninglight[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PickUp(Transform destnation)
    {
        gameM.RemovePower(50);
        IsOn = !IsOn;        
        GameM.LockDown = IsOn;
        ButtonSource.PlayOneShot(buttonClickSound, 1f);
        iTween.MoveTo(Button, iTween.Hash("position", buttons[IsOn ? 0:1], "time", 0.5f, "easetype", iTween.EaseType.spring));
        iTween.MoveTo(Windows[0], iTween.Hash("position", WindosTransfrom[IsOn ? 0 : 1], "time",1f, "easetype", iTween.EaseType.easeInBounce));
        iTween.MoveTo(Windows[1], iTween.Hash("position", WindosTransfrom[IsOn ? 2 : 3], "time", 1f, "easetype", iTween.EaseType.easeInBounce));
        foreach (var X in WindowSource)
        {
            X.PlayOneShot(DoorSound, 1f);

        }
        if(IsOn == true)
        {
            Warninglight[1].SetActive(true);
            Warninglight[0].SetActive(false);
            foreach (var D in doorM)
            {            
                if (D.DoorON == false)D.openDOor(true);
            }
        }
        else
        {
            Warninglight[1].SetActive(false);
            Warninglight[0].SetActive(true);
        }
        
 

    }
    public void Drop()
    {

    }
    public void Use()
    {
        IsOn = !IsOn;
        ButtonSource.PlayOneShot(buttonClickSound, 1f);
        iTween.MoveTo(Button, iTween.Hash("position", buttons[IsOn ? 0 : 1], "time", 0.5f, "easetype", iTween.EaseType.spring));
    }

}
