using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heathM : MonoBehaviour
{
    public SpriteRenderer[] harts;
    public Sprite [] HartSPites;
    public Slider MajicSlider;
    playerStats playerHarts;
    public Text textCoin;
     public void Start()
    {
    playerHarts = FindObjectOfType<playerStats>();
    removeAddHarts(playerHarts.curentHP);
        MajicSlider.value = playerHarts.currentMagic;
        MajicSlider.minValue = 1;
        MajicSlider.maxValue = playerHarts.MaxHP;
        textCoin.text = playerHarts.Coins.ToString();
    }
    public void addcoins(int Add)
    {
        playerHarts.Coins += Add;
        textCoin.text = playerHarts.Coins.ToString();

    }
    public void removeAddHarts(int hartsMax)
    {
        for (int i = 0; i < harts.Length; i++)
        {
            
            if (i<= playerHarts.MaxHP)
            {
            int X =  i<= hartsMax? 0:1;
            harts[i].sprite = HartSPites[X];
            }
            else harts[i].sprite = HartSPites[2];


        }

    }
}
