using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MenuManager : MonoBehaviourSingletonPersistent<MenuManager>
    {
        [SerializeField] protected GameObject setting;
        [SerializeField] protected GameObject main;
        [SerializeField] protected GameObject choseMap;
        [SerializeField] protected List<GameObject> star;
        [SerializeField] protected GameObject StarPrefabs;
        [SerializeField] public int n = 0;
        public void onCLickChoseMap()
        {
            SceneManager.LoadScene("SeneDemo");
        }
        public void onClickExit()
        {
            Application.Quit();
        }
        public void LoadSetting()
        {
            this.main.gameObject.SetActive(false);
            this.choseMap.gameObject.SetActive(false);
            Instantiate(setting).gameObject.SetActive(true);
        }
        public void ButtonBack()
        {
            this.main.gameObject.SetActive(true);
            Destroy(this.setting);
            Destroy(this.choseMap);
        }
        public void LoadStar()
        {
            for (int i = 0; i < n; i++)
            {
                star[i] = Instantiate(this.StarPrefabs, star[i].transform.position, star[i].transform.rotation);
            }

        }
        private void Update()
        {
            LoadStar();
        }

    }
}

