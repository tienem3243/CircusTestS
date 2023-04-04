using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour
{
    private ParticleSystem ptst;
    void Start()
    {
        ptst = gameObject.GetComponentInChildren<ParticleSystem>();
        ptst.Stop(true);
    }

    void OnMouseDown()
    {
        ptst.Play(true);
    }

    void OnMouseUp()
    {
        ptst.Stop(true);
    }

}
