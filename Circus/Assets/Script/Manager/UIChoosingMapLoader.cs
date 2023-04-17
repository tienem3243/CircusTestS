using UnityEngine;
using UnityEngine.UI;
using Slicer2D.Demo;
using System.Collections;

namespace Manager
{
    public class UIChoosingMapLoader : MonoBehaviour
    {
        public MapButton MapBtnPrefab;
        public Transform rootTransform;
        public GameObject board;
        public void onClickExit()
        {
            Application.Quit();
        }
        private void Start()
        {
            
           StartCoroutine( loadMapButtonDetail());
        }

        public IEnumerator loadMapButtonDetail()
        {
            yield return new WaitUntil(() => MapManager.Instance.getMapsInfo() != null);
            var mapInfo = MapManager.Instance.getMapsInfo();
            int i = 0;
            foreach (var map in mapInfo)
            {
                int j = i;
                MapButton info = Instantiate(MapBtnPrefab, rootTransform);
                info.displayStar(map.star);
                info.displayLevelIndex(j);
                info.onClick?.AddListener(() =>
                {
                    MapManager.Instance.SetGame(j);
                    board.SetActive(false);
                });
                i++;
            }
   

        }
        public void showUI()
        {
            board.SetActive(true);
        }
    }
}

