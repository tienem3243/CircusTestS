using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorHelper 
{
    
  
    public static Vector3 Intersect(Vector3 line1V1, Vector3 line1V2, Vector3 line2V1, Vector3 line2V2)
    {
        //Line1
        float A1 = line1V2.y - line1V1.y;
        float B1 = line1V1.x - line1V2.x;
        float C1 = A1 * line1V1.x + B1 * line1V1.y;

        //Line2
        float A2 = line2V2.y - line2V1.y;
        float B2 = line2V1.x - line2V2.x;
        float C2 = A2 * line2V1.x + B2 * line2V1.y;

        //Crammer
        float delta = A1 * B2 - A2 * B1;



        if (delta == 0)
            throw new ArgumentException("Lines are parallel");

        float x = (B2 * C1 - B1 * C2) / delta;
        float y = (A1 * C2 - A2 * C1) / delta;
        return new Vector3(x, y);
    }
}
