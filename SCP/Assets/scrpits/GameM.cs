using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{
    public static bool playerMoving = true;
    public static bool LockDown = false;
     public float curentPower = 100;
    public PlayerStuff playerStuff;
    public List<SaveStats> Save = new List<SaveStats>();
    [System.Serializable]
    public class SaveStats
    {
        public bool[]DoorsOpen;
        public List<collectibleCard> Tapes = new List<collectibleCard>();
    }
    [System.Serializable]
   public class PlayerStuff
    {
        public PlayerLook playerLook;
        public GameObject playerReticle;
        public GameObject PlayerCam;
 
    }
  public void turnOfAndOnPlayer(bool isOn)
    {
       playerMoving = isOn;
        playerStuff.playerReticle.SetActive(isOn);
        playerStuff.PlayerCam.SetActive(isOn);

   }

    public void RemovePower(float powerToRemove)
    {
        curentPower -= powerToRemove;
        float role = Random.Range(0, curentPower);
        if (role <= 50) Debug.Log("blackout");
        if (curentPower <= 0) Debug.Log("backout");
    }

    
}
