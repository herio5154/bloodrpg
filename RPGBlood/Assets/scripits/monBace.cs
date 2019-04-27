using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monBace : stats
{

    public Rigidbody2D monBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual  void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") coll.gameObject.GetComponent<Idamageable>().Damage(Att);
    }
}
