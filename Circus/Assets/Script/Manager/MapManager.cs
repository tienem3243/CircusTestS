using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Manager
{
    public class MapManager : MonoBehaviourSingletonPersistent<MapManager>
    {
        private string mapNameFolder = "Map/";
        public RectTransform UIChoosingMap;
        public int currentSceneID = 0;

        private GameObject[] gameScenes;
        private MapInfo[] mapInfos;

        public GameObject UICamera;
        public GameObject MainUI;

        private Vector3 startPosition;
        private GameObject currentScene = null;

        public MapInfo[] getMapsInfo()
        {
            return mapInfos;
        }
        public MapInfo getMapInfoByID(int i)
        {
            if (i > mapInfos.Length) return new MapInfo();
            return mapInfos[i];
        }
        public MapInfo getCurrentMapInfo()
        {
            return getMapInfoByID(currentSceneID);
        }

        private MapInfo[] loadMapInfo(string path)
        {
            return Resources.LoadAll<MapInfo>(path);
        }
   
        private GameObject[] loadGameScene(string path)
        {
           return Resources.LoadAll<GameObject>(path);
        }

        public void SetGame(int id)
        {
            if (id < 0 || id > gameScenes.Length) throw new IndexOutOfRangeException();
            Destroy(currentScene);
            currentScene = Instantiate(gameScenes[id]); 
            UICamera.SetActive(false);
            MainUI.SetActive(false);
        }

        [ContextMenu("Next")]
        public void NextGame()
        {
            SetGame(currentSceneID + 1);
        }

        [ContextMenu("Previous")]
        public void PreviousGame()
        {
            SetGame(currentSceneID - 1);
        }

        void Start()
        {
            startPosition = UIChoosingMap.anchoredPosition;
            gameScenes=loadGameScene("Prefab/"+mapNameFolder);
            mapInfos = loadMapInfo("Data/" + mapNameFolder);
        }


    }

}
