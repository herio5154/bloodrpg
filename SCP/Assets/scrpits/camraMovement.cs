using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camraMovement : MonoBehaviour
{
    public Transform[] LeftAndRight;
    public GameObject camraOBJ;
    public bool  IsOn;
    public float Speed;
    private bool lef;
 
    // Start is called before the first frame update
    public void OnEnable()
    {
        IsOn = true;
        camraOBJ.transform.rotation = LeftAndRight[2].rotation;
        StartCoroutine(moveCam());
    }
    public void OnDisable()
    {
        StopAllCoroutines();
     }
     
    IEnumerator moveCam()
    {
        yield return new WaitForSeconds(2f);
        while (IsOn == true)
        {
 
            iTween.RotateTo(camraOBJ, iTween.Hash("rotation", LeftAndRight[lef ? 0 : 1], "time", Speed, "easetype", iTween.EaseType.linear));
            yield return new WaitForSeconds(Speed+1);
            lef = !lef;

        }

    }
}
