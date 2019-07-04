using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftM : MonoBehaviour
{
    public GameObject Door;
    public Transform DoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(Door, iTween.Hash("position", DoorOpen, "time", 3, "easetype", iTween.EaseType.spring));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
