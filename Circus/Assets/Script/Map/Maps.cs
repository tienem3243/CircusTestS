using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Map" , menuName = "Maps/CreateNewMap")]
public class Maps : ScriptableObject
{
    public int id;
    public MapType name;
    public int star;
    public bool playAble;
}
