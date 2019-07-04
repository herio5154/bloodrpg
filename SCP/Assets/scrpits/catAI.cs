using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAI : EnemySight
{
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInSight == true)
        {
            transform.LookAt(Player.transform.position);
        }
     }
}
