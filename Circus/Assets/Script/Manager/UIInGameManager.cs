using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Manager
{
    public partial class UIInGameManager : MonoBehaviourSingleton<UIInGameManager>
    {
        [SerializeField] public ShowStar ShowStar;
        [SerializeField] private GameObject UiWinGame;
        [SerializeField] private GameObject UiInGame;
        public void ReStartMap()
        {
            MapManager.Instance.SetGame(MapManager.Instance.currentSceneID);
            UiWinGame.gameObject.SetActive(false);
            Debug.Log("call this method");
            ResetGame();

        }
        public void BackChoseMap()
        {
            //MapManager.Instance.SetGame(MapManager.Instance.currentSceneID);
            //MapManager.Instance.UICamera.gameObject.SetActive(true);
            UiWinGame.gameObject.SetActive(false);
            ResetGame();
        }
        public void NextMap()
        {
            if (!MapManager.Instance.getMapInfoByID(MapManager.Instance.currentSceneID + 1).playAble) return;
            MapManager.Instance.NextGame();
            UiWinGame.gameObject.SetActive(false);
            ResetGame();
        }
        public void PrevMap()
        {
            MapManager.Instance.PreviousGame();
            UiWinGame.gameObject.SetActive(false);
            ResetGame();
        }
        public void EatStar()
        {
            ShowStar.disPlayStarGamePlay(GameManager.Instance.countStart);
        }
        public void disPlayUiInGame()
        {
            UiInGame.gameObject.SetActive(true);
        }
        public void disPlayUiWinGame()
        {
            UiWinGame.gameObject.SetActive(true);
        }
        private void ResetGame()
        {
            GameManager.Instance.isWin = false;
            GameManager.Instance.isLose = false;
            if (GameManager.Instance.countStart == 0) return;
            ShowStar.disPlayNoneStarInGame(GameManager.Instance.countStart);
            GameManager.Instance.countStart = 0;
        }

    }
}