using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum ButtonKind {play,Stop,eject,NA}
public interface IIntractable
{
    void PickUp(Transform destnation);
    void Drop();
    void Use();
}
