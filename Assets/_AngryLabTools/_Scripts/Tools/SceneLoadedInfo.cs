using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AngryLab
{
    public class SceneLoadedInfo : MonoBehaviour
    {
        public static SceneLoadedInfo instance;

        [SerializeField] private string _currentSceneName;
        [SerializeField] private UEvents.EScene _onSceneLoaded;

        void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _currentSceneName = scene.name;
            _onSceneLoaded?.Invoke(scene);
        }

    }
}