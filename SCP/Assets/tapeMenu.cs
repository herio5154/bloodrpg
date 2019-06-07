using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class tapeMenu : menuM
{
    public AudioSource TapePlayer;    
    public Slider SoundSLider;
    public float AudoTime;
     
    public override void OnEnable()
    {
        base.OnEnable();
        MakeList();

    }
  
     
    public override void perfromAction(int ID)
    {
        MenuID = ID;
        tapePlay();
        changeMenu(1);
     }

    public override void changeMenu(int menuID)
    {
        if (menuID == 0)
        {
            stopTape();
        }
            base.changeMenu(menuID);
     }
    public void tapePlay()
    {
      
        Header.text = collectibleList[MenuID].FileName;
        TapePlayer.clip = collectibleList[MenuID].TapeSound;
        AudoTime = 0.5f;
        SoundSLider.maxValue = TapePlayer.clip.length;
        SoundSLider.value = AudoTime;
        TapePlayer.Play();
        StartCoroutine(TapeTime());
        infoText.text = tapeText(MenuID);
     }
    public void stopTape()
    {
        StopAllCoroutines();
        SoundSLider.value = 0;
        TapePlayer.Stop();
    }
 
    public string tapeText(int tapeID)
    {
        if(collectibleList[MenuID].HasFile == true)
        {
            string TapeText = collectibleList[MenuID].filesCards[0].Headeer+":"+"\n";
         
            foreach (var x in collectibleList[MenuID].filesCards[0].Text)
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
