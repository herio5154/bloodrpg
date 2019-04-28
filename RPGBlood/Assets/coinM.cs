using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinM : MonoBehaviour
{
    public int CoinValue;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            heathM H = FindObjectOfType<heathM>();
            H.addcoins(CoinValue);            
            Debug.Log("hay");
            Destroy(gameObject);
        }
}
}
