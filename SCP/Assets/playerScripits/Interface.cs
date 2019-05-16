﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public interface IIntractable
{
    void PickUp(Transform destnation);
    void Drop();
    void Use();
}
