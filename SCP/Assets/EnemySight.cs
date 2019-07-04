using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class EnemySight : MonoBehaviour
{
    public GameObject Player;
    public bool PlayerInSight;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInSight = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInSight = false;
        }

    }
}
