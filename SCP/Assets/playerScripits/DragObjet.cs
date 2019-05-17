using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjet : MonoBehaviour,IIntractable
{
    private bool holding;
    private Vector3 offset;
    private Transform player;
   
    // Update is called once per frame
    void Update()
    {
        if (holding == true)
        {
            transform.position = player.position + offset;
          
        }
    }
    public virtual void Use()
    {

    }
    public virtual void PickUp(Transform PlayerHands)
    {
        offset = gameObject.transform.position - PlayerHands.position;
        holding = true;
        player = PlayerHands;
        this.transform.position = PlayerHands.position;
         GetComponent<Rigidbody>().useGravity = false;

    }
    public void Drop()
    {
        holding = false;
        GetComponent<Rigidbody>().useGravity = true;
     }

}
