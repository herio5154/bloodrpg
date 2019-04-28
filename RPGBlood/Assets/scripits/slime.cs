using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : monBace,Idamageable
{
    public bool Ismoveing = true,test;
    public float Movetime,MoveSpeed;
    public GameObject Death,Coin;
    public void Start()
    {
        StartCoroutine(moveining());
    }
    public void Damage(int DamageAmount)
    {
        int Dam = DamageAmount - Deff <=0 ? 1: DamageAmount - Deff;
         curentHP -= (Dam);
        if(curentHP<=0)
        {
            Instantiate(Death, gameObject.transform.position, Quaternion.identity);
            Instantiate(Coin,gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

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
