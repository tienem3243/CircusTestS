using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public delegate void removeFromChain(int i);
    public removeFromChain remove;
    public int index;

    private void OnDisable()
    {
        remove.Invoke(index);
    }

 
}
