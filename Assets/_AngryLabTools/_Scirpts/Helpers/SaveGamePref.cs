using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AngryLab
{
    public class SaveGamePref : MonoBehaviour
    {
        [SerializeField] private SO_GeneralSettings gameSettings;

        [SerializeField] private UnityEvent OnSavedEvent;
        [SerializeField] private UEvents.EGeneralSettings OnLoadedEvent;

        [Button("SaveSettings", "Save Settings", ButtonAttribute.ButtonWidth.Large, ButtonAttribute.Colors.Green)]
        public void SaveSettings()
        {
            PlayerPrefs.SetString("Settings", ConvertToJSON(gameSettings));
#if UNITY_EDITOR
            Debug.Log("Saved Settings");
#endif
            if (OnSavedEvent != null)
            {
                OnSavedEvent.Invoke();
            }
        }

        [Button("LoadSettings", "Load Settings", ButtonAttribute.ButtonWidth.Large, ButtonAttribute.Colors.Yellow)]
        public void LoadSettings()
        {
            string val = PlayerPrefs.GetString("Settings");
            if (!string.IsNullOrEmpty(val))
            {
                ConvertJSONToClass(val, gameSettings);

#if UNITY_EDITOR
                Debug.Log("Loaded Settings");
#endif
                if (OnLoadedEvent != null)
                {
                    OnLoadedEvent.Invoke(gameSettings);
                }
            }
            else
            {
                OnLoadedEvent.Invoke(gameSettings);
            }
        }

        string ConvertToJSON(object obj)
        {
            return JsonUtility.ToJson(obj);
        }

        void ConvertJSONToClass(string obj, object overrideObj)
        {
            JsonUtility.FromJsonOverwrite(obj, overrideObj);
        }

    }
}
