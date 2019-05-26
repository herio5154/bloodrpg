using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeLoadeer : MonoBehaviour
{
    public Transform spot;
    public tapeM TapeM;
    // Start is called before the first frame update
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Tape>() != null)
        {
        TapeM.TapeLoad(other.gameObject);
        }
    }
     
}
