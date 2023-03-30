using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [ContextMenu("sss")]
    public void toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
