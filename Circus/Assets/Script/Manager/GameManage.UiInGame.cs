using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Manager
{
    public partial class GameManager
    {
        public void PickupStar()
        {
            countStart++;
            UIInGameManager.Instance.EatStar();
        }
        public void UiWInGame()
        {
            UIInGameManager.Instance.disPlayUiWinGame();
        }
        private void FixedUpdate()
        {
            this.WinGame();
            this.LoseGame();

        }
        public void WinGame()
        {
            if (!isWin) return;
            MapManager.Instance.setDataMap(MapManager.Instance.currentSceneID);
            this.Win();
        }
        public void LoseGame()
        {
            if (!isLose) return;
            GameManager.Instance.isLose = false;
            this.Lose();
            
        }
        public void ReloadMap()
        {
            UIInGameManager.Instance.ReStartMap();
        }
    }
}