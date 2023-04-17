using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
public class ShowStar : MonoBehaviour
{
    [SerializeField] public GameObject[] star;
    public void disPlayStarGamePlay(int amount)
    {
        if (amount == 0) return;
        amount = Mathf.Clamp(amount, 0, 3);
        for (int i = 1; i <= amount; i++)
        {
            star[i - 1].SetActive(true);
        }
    }
    public void disPlayNoneStarInGame(int amount)
    {
        if (amount == 0) return;
        amount = Mathf.Clamp(amount, 0, 3);
        for (int i = 1; i <= amount; i++)
        {
            star[i - 1].SetActive(false);
        }
    }
}