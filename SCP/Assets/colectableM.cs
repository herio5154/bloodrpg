using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectableM : MonoBehaviour
{
    public int ID;
    public menuM menuM;
    public void SHowColectable()
    {
        menuM.perfromAction(ID);
    }


}
