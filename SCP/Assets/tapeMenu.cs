using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class tapeMenu : menuM
{
    public AudioSource TapePlayer;    
    public Slider SoundSLider;
    public float AudoTime;
    private int tapeID;
    
    public override void OnEnable()
    {
        base.OnEnable();
        MakeList();

    }
    public void MakeList()
    {
        for (int i = 0; i < buttonText.Length; i++)
        {
            if (couter< GameM.Save[0].Tapes.Count)
            {
                buttonText[i].text = GameM.Save[0].Tapes[couter].FileName;
                colecTables[i].ID = couter;
                couter++;
             }
            else
            {
                buttons[i].SetActive(false);
            }
        }
     }
    public override void perfromAction(int ID)
    {
        tapeID = ID;
        tapePlay();
        changeMenu(1);
        tapePlay();
    }
    public void MenuControl(bool Add)
    {
        if(Add == true)
        {
            if (couter < GameM.Save[0].Tapes.Count)
            {
                MakeList();
            }
            return;
        }
        if(Add == false)
        {
            couter -= buttonText.Length+1;
            if (couter < 0) couter = 0;
            MakeList();
        }

    }
    
 
    public void tapePlay()
    {
        Header.text = GameM.Save[0].Tapes[tapeID].FileName;
        TapePlayer.clip = GameM.Save[0].Tapes[tapeID].TapeSound;
        AudoTime = 0.5f;
        SoundSLider.maxValue = TapePlayer.clip.length;
        SoundSLider.value = AudoTime;
        TapePlayer.Play();
        StartCoroutine(TapeTime());
        infoText.text = tapeText(tapeID);
     }
    public void stopTape()
    {
        SoundSLider.value = 0;
        TapePlayer.Stop();
    }
 
    public string tapeText(int tapeID)
    {
        if(GameM.Save[0].Tapes[tapeID].HasFile == true)
        {
            string TapeText = GameM.Save[0].Tapes[tapeID].filesCards[0].Headeer+":"+"\n";
         
            foreach (var x in GameM.Save[0].Tapes[tapeID].filesCards[0].Text)
            {
                TapeText += x+"\n"; 
            }
            return TapeText;
        }
        return "no File";
    }
    IEnumerator TapeTime()
    {

      while(TapePlayer.isPlaying == true)
        {
            yield return new WaitForSeconds(0.5f);
            AudoTime += 0.5f;
            SoundSLider.value = AudoTime;
        }
    }

}
