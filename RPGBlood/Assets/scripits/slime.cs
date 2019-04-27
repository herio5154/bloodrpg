using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monBace,Idamageable
{
    public bool Ismoveing = true,test;
    public float Movetime,MoveSpeed;
    public void Start()
    {
        StartCoroutine(moveining());
    }
    public void Damage(int DamageAmount)
    {
        curentHP -= (DamageAmount - Deff);
    }
  
    IEnumerator moveining()
    {
        while(Ismoveing == true)
        {
            
            Vector3 moveDir = new Vector3(Random.Range(-1f, 1f) * MoveSpeed, Random.Range(-1f, 1f) * MoveSpeed, 0);
            monBody.velocity = moveDir;
            yield return new WaitForSeconds(Movetime);
             
        }
         
   
    }
    
}
