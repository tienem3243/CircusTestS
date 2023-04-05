using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class SoundManager : MonoBehaviourSingletonPersistent<SoundManager>
    {
        [Header("Sound Manager")]
        [SerializeField] Slider volumnSilder;
        private void Start()
        {
            if (PlayerPrefs.HasKey("hey of music"))
            {
                PlayerPrefs.SetFloat("Key of musci", 1);
                this.Load();
            }
            else
                this.Load();
        }
        public void ChanngeVolume()
        {
            AudioListener.volume = volumnSilder.value;
            this.Save();

        }
        private void Load()
        {
            volumnSilder.value = PlayerPrefs.GetFloat("key Naem of Music ");
        }
        private void Save()
        {
            PlayerPrefs.SetFloat("key Naem of Music ", volumnSilder.value);
        }
    }
}

