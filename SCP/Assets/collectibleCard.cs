using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "collectible")]
public class collectibleCard : ScriptableObject
{
    public string FileName;
    public int ID;
    public bool HasFile;
    public AudioClip TapeSound;
    public List<FilesCard> filesCards = new List<FilesCard>();
}
[System.Serializable]
public class FilesCard
{
    public string Headeer;
    public string[] Text;

}




