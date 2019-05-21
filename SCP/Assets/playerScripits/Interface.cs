using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum ButtonKind {play,Stop,pasue,eject }
public interface IIntractable
{
    void PickUp(Transform destnation);
    void Drop();
    void Use();
}
