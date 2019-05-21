using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapeLoadeer : MonoBehaviour
{
    public Transform spot;
    public tapeM TapeM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("i live");
        TapeM.TapeLoad(other.gameObject);
    }
     
}
