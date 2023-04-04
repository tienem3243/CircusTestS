using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle : MonoBehaviour
{
    private float bonce = 40f;
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.transform);
        gameObject.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - other.transform.position)  * bonce,ForceMode2D.Impulse);
    }
}
