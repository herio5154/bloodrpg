using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour
{
    public Transform spot;

    public void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = spot.transform.position;
        Debug.Log("i work");
    }
}
