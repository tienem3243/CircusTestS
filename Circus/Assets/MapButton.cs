using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MapButton : Button
{
    [SerializeField]public GameObject[] stars;
    [SerializeField] private TextMeshProUGUI mapIndex;

    public void displayStar(int amount)
    {
        amount = Mathf.Clamp(amount, 0, 2);
       for(int i = 0; i <amount; i++)
        {
            stars[i].SetActive(true);
        }
    }
    public void displayLevelIndex(int i)
    {
        mapIndex.text = (i+1).ToString();
    }
    public void displayLevelIndex(string i)
    {
        mapIndex.text = i;
    }


}
