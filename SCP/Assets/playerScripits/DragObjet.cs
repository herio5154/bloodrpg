using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjet : MonoBehaviour,IIntractable
{
    private bool holding;
    private Vector3 offset;
    private Transform player;
    public Rigidbody objrigidbody;
    // Update is called once per frame
    public void Update()
    {
        if (holding == true)
        {
            Camera.main.transform.LookAt(transform.position);
            transform.position = player.position + offset;

        }

    }

    public  virtual void PickUp(Transform PlayerHands)
    {
        offset = gameObject.transform.position - PlayerHands.position;
        holding = true;
        player = PlayerHands;
        this.transform.position = PlayerHands.position;
        objrigidbody.useGravity = false;
        PlayerLook.lockCamra = true;

    }
    public virtual void Drop()
    {
        holding = false;
        objrigidbody.useGravity = true;
        PlayerLook.lockCamra = false;
        
    }
    public virtual void Use()
    {

    }

}
