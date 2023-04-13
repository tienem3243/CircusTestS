using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class CheckLose : MonoBehaviour
{

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Candy"))
        {
            Debug.Log("Lose");
            GameManager.Instance.isLose = true;
        }
    }
}
