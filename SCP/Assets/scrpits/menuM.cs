using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuM : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject MainMenu;
    public GameObject [] nextAndBack;

    public int couter;
    public int MenuID;
    public Text Header;
    public Text infoText;
    public GameM GameM;
    public Text[] buttonText;
    public GameObject[] buttons;
    public int  colectableID;
    public colectableM [] colectableButtons;
    public ColectableKind colectableTyipe;
    public List<collectibleCard> collectibleList = new List<collectibleCard>();

    public virtual void OnEnable()
    {
        collectibleList.Clear();
        foreach (var x in GameM.Save[0].collectibles)
        {
            if(x.Colectable == colectableTyipe)
            {
            collectibleList.Add(x);
            }
        }
        couter = 0;
        changeMenu(0);
    }
    public void MenuControl(bool Add)
    {

        if (Add == true)
        {
            if (couter < collectibleList.Count)
            {
                MakeList();
            }              
            return;
        }
        if (Add == false)
        {
            couter -= buttonText.Length + 1;
            if (couter < 0) couter = 0;
            MakeList();
        }

    }
    public void MakeList()
    {
        nextAndBack[0].SetActive(couter > 0);
        if(collectibleList.Count > buttonText.Length)
        {
        nextAndBack[1].SetActive(couter <= 0);
        }
        else nextAndBack[1].SetActive(false);


        for (int i = 0; i < buttonText.Length; i++)
        {
            buttons[i].SetActive(false);
            if (couter < collectibleList.Count)
            {
                buttons[i].SetActive(true);
                buttonText[i].text = collectibleList[couter].FileName;
                colectableButtons[i].ID = couter;
                couter++;
            }
           
        }
    }
    public virtual void changeMenu(int menuID)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == menuID);
        }
    }
    public virtual void perfromAction(int ID)
    {
        Debug.Log("colectable");
    }
    public void returnToMenu()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
