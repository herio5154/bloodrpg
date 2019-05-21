using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapeM : MonoBehaviour
{
    // Start is called before the first frame update
    public KeysSetup[] keys;
    public GameObject thingToRotate,TapeLoader;
    public Transform [] RotPos;
     public bool LidOpen;
    public GameObject tape;

    public void hitKeys(ButtonKind buttonID)
    {
         foreach (var X in keys)
        {
            if(X.Button != buttonID)
            {
                X.isDown = false;
                iTween.MoveTo(X.buttonObj, iTween.Hash("position", X.KeyPos[1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
                Act(false, X.Button);             
            }
 
        }
        keys[(int)buttonID].isDown = !keys[(int)buttonID].isDown;
        iTween.MoveTo(keys[(int)buttonID].buttonObj, iTween.Hash("position", keys[(int)buttonID].KeyPos[keys[(int)buttonID].isDown ? 0 : 1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
        Act(keys[(int)buttonID].isDown,buttonID);

    }

    public void Act(bool Down,ButtonKind button)
    {
        if(Down == true)
        {
            if (button == ButtonKind.eject)
            {
                Debug.Log("hit");
                LidOpen = !LidOpen;
                Debug.Log(LidOpen ? 0 : 1);
                iTween.RotateTo(thingToRotate, iTween.Hash("rotation", RotPos[LidOpen ? 0 : 1], "time", 0.5, "easetype", iTween.EaseType.easeInOutBounce));
                TapeLoader.SetActive(LidOpen);
                return;
            }

               
        }
        if(Down == false) 
        {
            if (button == ButtonKind.eject)
            {
                LidOpen = false;
                iTween.RotateTo(thingToRotate, iTween.Hash("rotation", RotPos[1], "time", 0.5, "easetype", iTween.EaseType.easeInOutBounce));
                TapeLoader.SetActive(LidOpen);
                return;
            }
        }
    }
    public void TapeLoad(GameObject test)
    {
        LidOpen = false;
        Destroy(test);
        tape.SetActive(true); 
        iTween.RotateTo(thingToRotate, iTween.Hash("rotation", RotPos[1], "time", 0.5, "easetype", iTween.EaseType.easeInOutBounce));
        foreach (var X in keys)
        {           
                X.isDown = false;
                iTween.MoveTo(X.buttonObj, iTween.Hash("position", X.KeyPos[1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
        }
    }

    [System.Serializable]
    public class KeysSetup
    {
        public ButtonKind Button;
        public Transform[] KeyPos;
        public GameObject buttonObj;
        public bool isDown;

    }

}
