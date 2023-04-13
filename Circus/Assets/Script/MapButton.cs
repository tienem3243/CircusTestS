using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

    public class MapButton : Button
    {
        [SerializeField] public GameObject[] stars;
        [SerializeField] private TextMeshProUGUI mapIndex;

        public void displayStar(int amount)
        {
        if (amount == 0) return;
            amount = Mathf.Clamp(amount, 0, 3);
            for (int i = 1; i <= amount; i++)
            {
                stars[i-1].SetActive(true);
            }
        }
        public void displayLevelIndex(int i)
        {
            mapIndex.text = (i + 1).ToString();
        }
        public void displayLevelIndex(string i)
        {
            mapIndex.text = i;
        }


    }


