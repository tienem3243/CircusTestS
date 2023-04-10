using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Manager
{
    public class MapManager : MonoBehaviourSingletonPersistent<MapManager>
    {

        public RectTransform UIObject;
        public RectTransform UIBack;

        public int currentSceneID = 0;

        public GameObject[] gameScenes;

        public GameObject demoCamera;
        public GameObject demoUI;

        private GameObject lastScene;
        private Vector3 startPosition;
        private GameObject currentScene = null;


        public MapInfo[] getMapsInfo()
        {
            return Resources.LoadAll<MapInfo>("Map/");
        }


        public void SetGame(int id)
        {
            Destroy(currentScene);
            currentScene = Instantiate(gameScenes[id]);
            demoCamera.SetActive(false);
            demoUI.SetActive(false);
        }





        public void SetMainMenu()
        {
            lastScene = currentScene;
            currentScene = null;
        }

        void Start()
        {
            startPosition = UIObject.anchoredPosition;
            Application.targetFrameRate = 60;
        }


    }

}
