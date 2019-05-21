using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeButtons : MonoBehaviour,IIntractable

{
    public tapeM Tape;
    public ButtonKind Button;
    static bool wait;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void PickUp(Transform destnation)
    {
        if(wait == false)
        {
            Tape.hitKeys(Button);
            wait = true;
            StartCoroutine(waitthis());
        }
    }
    public void Drop()
    {

    }
    public void Use()
    {
        if (wait == false)
        {
            Tape.hitKeys(Button);
            wait = true;
            StartCoroutine(waitthis());
        }
    }
    IEnumerator waitthis()
    {
         yield return new WaitForSeconds(1);
        wait = false;
 
    }
}
