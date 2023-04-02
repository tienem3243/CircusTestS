using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
  
    public removeFromChain remove;
    public int index;

    public delegate void removeFromChain(int i);

    private void OnDisable()
    {
        remove.Invoke(index);
    }
}
