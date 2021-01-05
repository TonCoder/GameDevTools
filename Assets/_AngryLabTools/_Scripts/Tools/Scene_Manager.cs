using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using AngryLab;

public class Scene_Manager: MonoBehaviour
{
    public static Scene_Manager instance;
    [SerializeField] private string _currentSceneName;

    [Header("Async Load Settings"), SerializeField] private string _loadingSceneName;
    [SerializeField] private string _mainTitleSceneName;

    [Header("Loading Scene Objects"), SerializeField] private TextMeshProUGUI _loadText;
    [SerializeField] private Slider _loadSlider;

    [Space(10)]
    [Header("Testing Loading Screen"), SerializeField] private bool _testingLoading;
    [SerializeField] private float _timeToLoadGoal = 100;
    [SerializeField] private float _timePassed = 100;

    [Space]
    [SerializeField] private UEvents.EScene sceneLoaded;

    private static string _sceneToLoadAsync;

    private void Start() {
        if (_testingLoading){
            StartCoroutine(LoadAsyncSceneTest());
            sceneLoaded?.Invoke(SceneManager.GetActiveScene());
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        _loadSlider = _loadSlider ? _loadSlider : GetComponent<Slider>();
        _loadText = _loadText ? _loadText : GetComponent<TextMeshProUGUI>();
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Awake(){
        Singleton();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (_testingLoading) return;

        _currentSceneName = scene.name;
        if(scene.name == _loadingSceneName)
        {
            _sceneToLoadAsync = string.IsNullOrEmpty(_sceneToLoadAsync) ? _mainTitleSceneName : _sceneToLoadAsync;
            StartCoroutine(LoadAsyncScene());

            // if(_sceneToLoadAsync.Contains("CharacterSelect") && GameManager.instance.pInfo.UserItms.Count <= 0){
            //     // get pfabActions and call GET player INV

            // }else{
            //     StartCoroutine(LoadAsyncScene());
            // }
        }

       sceneLoaded?.Invoke(SceneManager.GetActiveScene());
    }

    //*****************************
    // Load Actions
    //*****************************
    public void LoadNextScene()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    
    public void LoadingScene(){
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

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneToLoadAsync, LoadSceneMode.Single);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // Calculate the Scene load rate/percent
            float loadedPercent = Mathf.Clamp01(asyncLoad.progress / 0.9f) * 100;

            if(_loadSlider != null)
            {
                _loadSlider.value = loadedPercent;
                _loadText.text = $"{loadedPercent}%";
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
                _loadText.text = (int) startTime + "%";
            }

            startTime += (Time.time / 100);
            _timePassed = startTime;
            yield return null;
        }

#if UNITY_EDITOR
        Debug.Log("DONE!");
#endif
        yield return null;
    }

    void Singleton(){
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
}
