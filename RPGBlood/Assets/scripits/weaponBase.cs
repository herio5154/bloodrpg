using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBase : MonoBehaviour
{
    public int Attck;

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<Idamageable>() != null) coll.gameObject.GetComponent<Idamageable>().Damage(Attck);
    }

}
