using AngryLab;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/// <summary>
/// This script takes advantage of Unity's Audio Mixer to best manage your audio settings in game.
/// Create volume variables for the mixers. follow the link "https://www.youtube.com/watch?v=7wWNAiWc8ws&feature=emb_title&ab_channel=Unity"
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicAndFxManager : MonoBehaviour
{
    public static MusicAndFxManager instance;

    [Header("General Settings")]
    [SerializeField] private SO_GeneralSettings gameSettings;

    [Header("Audio Mixer Setup")]
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixerGroup masterMixer;
    [SerializeField] private AudioMixerGroup musicMixer;
    [SerializeField] private AudioMixerGroup uiMixer;

    [Header("Audio Mixer Setup")]
    [SerializeField] private string musicVariableName = "MusicVol";
    [SerializeField] private string fxVariableName = "FXVol";

    [Header("Scene Music Info")]
    [SerializeField] private SO_MusicList _sceneMusicList;

    [Header("Audio Setup")]
    [SerializeField] private AudioSource musicASource;
    [SerializeField] private AudioSource uiASource;

    [Header("Snapshot Setup")]
    [SerializeField] private AudioMixerSnapshot startingSnapshot;
    [SerializeField] private AudioMixerSnapshot mutingSnapshot; 

    private AudioClip currentMusic;

    private void Start()
    {
        if(gameSettings == null)
        {
            Debug.Log("The SO_GeneralSettings has not been set in MusicAndFxManager");
            Debug.Break();
        }

        musicASource.outputAudioMixerGroup = musicMixer;
        uiASource.outputAudioMixerGroup = uiMixer;
        Singleton();
    }

    public void LevelFinishedLoading(Scene scene)
    {
        try
        {
            for (int i = 0; i < _sceneMusicList.musicList.Count; i++)
            {
                if(_sceneMusicList.musicList[i]._sceneName == scene.name && _sceneMusicList.musicList[i]._audioClip != currentMusic) {         
                    currentMusic = _sceneMusicList.musicList[i]._audioClip;
                    musicASource.clip = currentMusic;
                    musicASource.loop = true;
                    musicASource.Play();
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log($"Error loading Music: {ex.Message}");
        }
    }

    public void SetMainMusicLevel(float volume)
    {
        masterMixer.audioMixer.SetFloat(musicVariableName, volume);
        gameSettings.musicVol = (int)volume;
    }

    public void SetUiMusicLevel(float volume)
    {
        masterMixer.audioMixer.SetFloat(fxVariableName, volume);
        gameSettings.fxVol = (int)volume;
    }

    public void SoundSettingsLoaded(SO_GeneralSettings gsettings)
    {
        masterMixer.audioMixer.SetFloat(musicVariableName, gsettings.musicVol);
        masterMixer.audioMixer.SetFloat(fxVariableName, gsettings.fxVol);
    }

    public void ToggleMute(bool val)
    {
        if (val)
        {
            startingSnapshot.TransitionTo(0.5f);
        }
        else
        {
            mutingSnapshot.TransitionTo(0.5f);
        }
    }

    private void Singleton()
    {
        if(instance == null || instance != this)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
