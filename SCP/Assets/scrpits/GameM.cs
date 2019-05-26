using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    public static bool playerMoving = true;
    public static bool LockDown = false;
    public float curentPower = 100;
    

    public void RemovePower(float powerToRemove)
    {
        curentPower -= powerToRemove;
        float role = Random.Range(0, curentPower);
        if (role <= 50) Debug.Log("blackout");
        if (curentPower <= 0) Debug.Log("backout");
    }
}
