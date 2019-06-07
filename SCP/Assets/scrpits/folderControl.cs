using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folderControl : HoldingItems, IIntractable
{
     public float dis;
    public GameObject OpenObjet;
  

    public override void PickUp(Transform PlayerHands)
    {
   
            hands = PlayerHands;
            rigidBody.useGravity = false;
            rigidBody.isKinematic = true;
            rigidBody.velocity = Vector3.zero;
            this.transform.position = new Vector3(PlayerHands.position.x+dis, PlayerHands.position.y, PlayerHands.position.z);
            this.transform.parent = PlayerHands;
            isHolding = true;
        
    }
    
    public override void Use()
    {
        OpenObjet.transform.position = transform.position;
         OpenObjet.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log("on");

    }
}
