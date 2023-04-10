using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Map" , menuName = "Maps/CreateNewMap")]
public class MapInfo : ScriptableObject
{
    public int id;
    public string mapName;
    public int star;
    public bool playAble;
}
