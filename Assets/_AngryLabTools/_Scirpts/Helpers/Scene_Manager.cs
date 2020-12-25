using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

namespace AngryLab
{
    public class Scene_Manager : MonoBehaviour
    {
        public static Scene_Manager instance;
        [SerializeField] private string _currentSceneName;

        [Header("Async Load Settings"), SerializeField] private string _loadingSceneName;
        [SerializeField] private string _mainTitleSceneName;
        [SerializeField] private string _sceneToLoadAsync;


        [Header("Loading Scene Objects"), SerializeField] private TextMeshProUGUI _loadText;
        [SerializeField] private Slider _loadSlider;

        [Space(10)]
        [Header("Testing Loading Screen"), SerializeField] private bool _testingLoading;
        [SerializeField] private float _timeToLoadGoal = 100;
        [SerializeField] private float _timePassed = 100;

        // public delegate void SceneLoaded(Scene scene);
        // public event SceneLoaded _SceneLoaded;
        internal static UnityAction<Scene> sceneLoaded;

        private void Start()
        {
            if (_testingLoading)
            {
                StartCoroutine(LoadAsyncSceneTest());

                if (sceneLoaded != null)
                {
                    sceneLoaded.Invoke(SceneManager.GetActiveScene());
                }
            }
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // called when the game is terminated
        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void Awake()
        {
            Singleton();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (_testingLoading) return;

            _currentSceneName = scene.name;
            if (scene.name == _loadingSceneName)
            {
                _sceneToLoadAsync = string.IsNullOrEmpty(_sceneToLoadAsync) ? _mainTitleSceneName : _sceneToLoadAsync;

                StartCoroutine(LoadAsyncScene());

                // if(_sceneToLoadAsync.Contains("CharacterSelect") && GameManager.instance.pInfo.UserItms.Count <= 0){
                //     // get pfabActions and call GET player INV

                // }else{
                //     StartCoroutine(LoadAsyncScene());
                // }
            }

            if (sceneLoaded != null)
            {
                sceneLoaded.Invoke(SceneManager.GetActiveScene());
            }
        }

        //*****************************
        // Load Actions
        //*****************************
        public void LoadNextScene()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }

        public void LoadingScene()
        {
            SceneManager.LoadScene(1);
        }

        public void SetSceneToLoadAsync(string name)
        {
            _sceneToLoadAsync = name;
        }

        IEnumerator LoadAsyncScene()
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneToLoadAsync, LoadSceneMode.Single);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                // Calculate the Scene load rate/percent
                float loadedPercent = Mathf.Clamp01(asyncLoad.progress / 0.9f) * 100;

                // Grab Text and slider to assign values after getting the Component and it being valid
                if (_loadSlider == null)
                {
                    GameObject go = GameObject.FindGameObjectWithTag("_LoadingSlider");
                    _loadSlider = go != null ? go.GetComponent<Slider>() : null;
                }
                else
                {
                    _loadSlider.value = loadedPercent;
                }
                if (_loadText == null)
                {
                    GameObject go = GameObject.FindGameObjectWithTag("_LoadingText");
                    _loadText = go != null ? go.GetComponent<TextMeshProUGUI>() : null;
                }
                else
                {
                    _loadSlider.value = loadedPercent;
                }


                // scene has loaded as much as possible, the last 10% can't be multi-threaded
                if (asyncLoad.progress >= 0.9f)
                {
                    // we finally show the scene
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        IEnumerator LoadAsyncSceneTest()
        {
            float startTime = Time.time;

            // Wait until the asynchronous scene fully loads
            while (startTime < _timeToLoadGoal)
            {
                // Grab Text and slider to assign values after getting the Component and it being valid
                if (_loadSlider == null)
                {
                    GameObject go = GameObject.FindGameObjectWithTag("_LoadingSlider");
                    _loadSlider = go != null ? go.GetComponent<Slider>() : null;
                    _loadSlider.maxValue = _timeToLoadGoal;
                }
                else
                {
                    _loadSlider.value = startTime;
                }
                if (_loadText == null)
                {
                    GameObject go = GameObject.FindGameObjectWithTag("_LoadingText");
                    _loadText = go != null ? go.GetComponent<TextMeshProUGUI>() : null;
                }
                else
                {
                    _loadText.text = (int)startTime + "%";
                }

                startTime += (Time.time / 100);
                _timePassed = startTime;
                yield return null;
            }

            Debug.Log("DONE!");
            yield return null;
        }

        void Singleton()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}