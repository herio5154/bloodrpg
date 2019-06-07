using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folderOpen : MonoBehaviour,IIntractable
{
    public GameObject ClosedObjet;
    public GameObject OpenObj;
      
    public void PickUp(Transform destnation)
    {
     }
    public void Drop()
    {

    }
    public void Use()
    {
      
        ClosedObjet.SetActive(true);
        OpenObj.SetActive(false);
       
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Intractable"))
        {
            other.transform.parent = transform;
         }
    }


}
