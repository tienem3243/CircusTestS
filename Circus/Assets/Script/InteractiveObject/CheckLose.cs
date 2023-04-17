using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class CheckLose : MonoBehaviour
{

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Candy"))
        {
            Debug.Log("Lose");
            GameManager.Instance.isLose = true;
        }
    }
}
