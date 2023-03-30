using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slicer2D;
public class Spin : MonoBehaviour
{
    Vector3 spin;
    private void Start()
    {
        spin = Vector3.forward;
    }
    void Update()
    {
      
        transform.Rotate(spin);
    } 
}
