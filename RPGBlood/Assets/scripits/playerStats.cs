using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : stats,Idamageable
{
    public float Speed,currentMagic,MaxMajic;
    public int Coins;
    public heathM heath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection;
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        transform.Translate(moveDirection * Speed * Time.deltaTime);
    }
   public void Damage(int DamageAmount)
    {
        curentHP -= (DamageAmount-Deff);
        if (curentHP <= 0) Debug.Log("dead");
        heath.removeAddHarts(curentHP);
    }

}
