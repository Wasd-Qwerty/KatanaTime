using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")] [SerializeField] private List<SceneInfo> _scenesInfo;

    
    [SerializeField] private DoorController _doorController;

    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _levelsUI;
    [SerializeField] private GameObject _settingsUI;

    [SerializeField] private Text _musicButtonText;
    [SerializeField] private Text _sfxButtonText;
    
    private Color[] _colors = 
     {
         Color.red,
         Color.green, 
         Color.blue, 
     };
    
    private void Start()
    {

        if (PlayerPrefs.HasKey("SettingsMusicOn"))
        {
            var musicOnInt =  PlayerPrefs.GetInt("SettingsMusicOn");
            AudioManager.Instance.musicOn = musicOnInt == 1;
        }
        if (PlayerPrefs.HasKey("SettingsSfxOn"))
        {
            var sfxOnInt =  PlayerPrefs.GetInt("SettingsSfxOn");
            AudioManager.Instance.sfxOn = sfxOnInt == 1;
        }
        Time.timeScale = 1;
        ShowMain();
        LevelLoadInfo();
    }

    private void Update()
    {
        foreach (var sceneInfo in _scenesInfo)
        {
            sceneInfo.estimation.color = CheckColorForEstimation(sceneInfo.estimation.text);
        }

        CheckColorAudioSettings();
    }

    private void CheckColorAudioSettings()
    {
        _musicButtonText.color = AudioManager.Instance.musicOn ? Color.green : Color.red;
        _sfxButtonText.color = AudioManager.Instance.sfxOn ? Color.green : Color.red;
    }

    private void LevelLoadInfo()
    {
        foreach (var sceneInfo in _scenesInfo)
        {
            if (PlayerPrefs.HasKey(sceneInfo.nameOfScene + "BestScore"))
            {
                sceneInfo.bestScore.text = PlayerPrefs.GetInt(sceneInfo.nameOfScene + "BestScore").ToString();
            }
            else
            {
                sceneInfo.bestScore.text = "none";
            }
            if (PlayerPrefs.HasKey(sceneInfo.nameOfScene + "Estimation"))
            {
                var estimation = PlayerPrefs.GetString(sceneInfo.nameOfScene + "Estimation");
                sceneInfo.estimation.text = estimation;
            }
            else
            {
                sceneInfo.estimation.text = "none";
            }
        }

        Zaserino();
    }

    private void Zaserino()
    {
        List<string> estimationForUnlock = new List<string>() { "S", "A", "B"};
        for (int i = 1; i < _scenesInfo.Count; i++)
        {
            _scenesInfo[i].unlocked = estimationForUnlock.Contains(_scenesInfo[i - 1].estimation.text);
        }

        foreach (var sceneInfo in _scenesInfo)
        {
            sceneInfo.zaserino.SetActive(!sceneInfo.unlocked);
        }
    }

    Color CheckColorForEstimation(string estimation)
    {
        if (estimation == "none")
        {
            return Color.black;
        }
        if (estimation == "S")
        {
            return _colors[Random.Range(0,_colors.Length)];
        }
        if (estimation == "A")
        {
            return Color.green;
        }
        if (estimation == "B")
        {
            return Color.yellow;
        }
        return Color.red;
    }

    public void StartLevel(GameObject level)
    {
        _doorController.sceneName = level.name;
        _doorController.Occurrence();
        gameObject.SetActive(false);
    }

    public void ShowLevels()
    {
        _mainUI.SetActive(false);
        _levelsUI.SetActive(true);
        _settingsUI.SetActive(false);
    }

    public void ShowMain()
    {
        _mainUI.SetActive(true);
        _levelsUI.SetActive(false);
        _settingsUI.SetActive(false);
    }
    public void ShowSettings()
    {
        _mainUI.SetActive(false);
        _levelsUI.SetActive(false);
        _settingsUI.SetActive(true);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        LevelLoadInfo();
    }

    
    public void Music()
    {
        AudioManager.Instance.musicOn = !AudioManager.Instance.musicOn;
        var musicOnInt = AudioManager.Instance.musicOn ? 1 : 0; 
        PlayerPrefs.SetInt("SettingsMusicOn", musicOnInt);
        PlayerPrefs.Save();
    }
    
    public void Sfx()
    {
        AudioManager.Instance.sfxOn = !AudioManager.Instance.sfxOn;
        var sfxOnInt = AudioManager.Instance.sfxOn ? 1 : 0;
        PlayerPrefs.SetInt("SettingsSfxOn", sfxOnInt);
        PlayerPrefs.Save();
    }
}