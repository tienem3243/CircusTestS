using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class EatItem : MonoBehaviour
{
  
    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.CompareTag("Star")) return;
        GameManager.Instance.countStart++;
        coll.gameObject.SetActive(false);
    }
}
