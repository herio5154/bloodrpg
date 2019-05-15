using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INtractable
{
    void PickUp(Transform Pos);
    void Drop(float power);
}
