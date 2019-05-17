using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArciveBox : MonoBehaviour,IIntractable
{
    public GameObject Stuff,ArciveBoxObj;
 
    // Start is called before the first frame update
    void Start()
    {
        Stuff.SetActive(false);
    
    }

    public  void Use()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Im off");
        ArciveBoxObj.transform.parent = null;
        //Destroy(gameObject);
    }
    public  void PickUp(Transform PlayerHands)
    {


    }
    public  void Drop()
    {

    }

}
