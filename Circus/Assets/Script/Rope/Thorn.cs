using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    [SerializeField]GameObject thorColission;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
           
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            collision.GetComponent<Weight>().OnBreaking.Invoke();
      
        }
    }
}
