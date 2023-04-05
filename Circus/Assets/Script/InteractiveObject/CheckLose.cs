using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLose : MonoBehaviour
{

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Candy"))
        {
            Debug.Log("Lose");
            GameManger.Instance.isLose = true;
        }
    }
}
