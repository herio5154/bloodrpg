using System.Collections;
using UnityEngine;

public class tapeM : MonoBehaviour
{
    // Start is called before the first frame update
    public KeysSetup[] keys;
    public GameObject thingToRotate, TapeLoader;
    public Transform[] RotPos;
    public bool LidOpen;
    public GameObject tape;
    public Transform tapePos;
    public Transform spot;
    public AudioClip Tapesound;
    public AudioSource ButtonSource, TapeSource;
    public AudioClip ButoonClickSound, TapeCickSound;
    private bool tapeIn;

    public void hitKeys(ButtonKind buttonID)
    {
        ButtonSource.PlayOneShot(ButoonClickSound, 1f);

        foreach (var X in keys)
        {
            if (X.Button != buttonID)
            {
                X.isDown = false;
                iTween.MoveTo(X.buttonObj, iTween.Hash("position", X.KeyPos[1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
                Act(false, X.Button);
            }

        }
        keys[(int)buttonID].isDown = !keys[(int)buttonID].isDown;
        iTween.MoveTo(keys[(int)buttonID].buttonObj, iTween.Hash("position", keys[(int)buttonID].KeyPos[keys[(int)buttonID].isDown ? 0 : 1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
        Act(keys[(int)buttonID].isDown, buttonID);

    }

    public void Act(bool Down, ButtonKind button)
    {
        if (Down == true)
        {
            if (button == ButtonKind.eject)
            {
                LidOpen = !LidOpen;
                Debug.Log(LidOpen ? 0 : 1);
                iTween.RotateTo(thingToRotate, iTween.Hash("rotation", RotPos[LidOpen ? 0 : 1], "time", 0.5, "easetype", iTween.EaseType.easeInOutBounce));
                TapeLoader.SetActive(LidOpen);
                if (tape != null)
                {
                    tape.transform.position = spot.transform.position;
                    tape.GetComponent<Rigidbody>().useGravity = true;
                    tape.GetComponent<Collider>().enabled = true;
                    tape.transform.parent = null;
                    tape.name = tape.GetComponent<Tape>().TapeName;
                    tape = null;
                 }
                return;
            }
            if (button == ButtonKind.play)
            {
                Debug.Log("hit");
                TapeSource.PlayOneShot(Tapesound, 1f);
                StartCoroutine(PlayTape());
            }
            if (button == ButtonKind.Stop) TapeSource.Stop();


        }
        if (Down == false)
        {
            if (button == ButtonKind.eject)
            {
                LidOpen = false;
                iTween.RotateTo(thingToRotate, iTween.Hash("rotation", RotPos[1], "time", 0.5, "easetype", iTween.EaseType.easeInOutBounce));
                TapeLoader.SetActive(LidOpen);
                return;
            }
            if (button == ButtonKind.play) TapeSource.Stop();
        }
    }

   
    public void TapeLoad(GameObject TapeInfo)
    {
        TapeSource.PlayOneShot(TapeCickSound, 1f);
        LidOpen = false;        
        tape  = Instantiate(TapeInfo.GetComponent<Tape>().theTape,tapePos.position,tapePos.rotation);
        Tapesound = TapeInfo.GetComponent<Tape>().TapeSound;
        tape.GetComponent<Collider>().enabled = false;
        tape.GetComponent<Rigidbody>().useGravity = false;
         tape.transform.parent = tapePos;
        TapeLoader.SetActive(false);
        if (tapeIn == false) tapeIn = true;
        StartCoroutine(PlayTape());
         LidOpen = false;
        hitKeys(ButtonKind.play);
        Destroy(TapeInfo);
          
    }

    [System.Serializable]
    public class KeysSetup
    {
        public ButtonKind Button;
        public Transform[] KeyPos;
        public GameObject buttonObj;
        public bool isDown;

    }
    IEnumerator PlayTape()
    {
        while (TapeSource.isPlaying == true)
        {
            yield return new WaitForSeconds(0.5f);
        }
        iTween.MoveTo(keys[(int)ButtonKind.play].buttonObj, iTween.Hash("position", keys[(int)ButtonKind.play].KeyPos[1], "time", 0.5f, "easetype", iTween.EaseType.easeInExpo));
        keys[(int)ButtonKind.play].isDown = false;
        ButtonSource.PlayOneShot(ButoonClickSound, 1f);
        Debug.Log("done");


    }

}



