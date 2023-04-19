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
    [SerializeField] private GameObject _sureCheckUI;

    [SerializeField] private Text _musicButtonText;
    [SerializeField] private Text _sfxButtonText;

    [SerializeField] private List<GameObject> _levelObjects;

    private Color[] _colors = 
     {
         Color.red,
         Color.green, 
         Color.blue, 
     };
    
    private void Start()
    {
        CheckAudioSettings();
        Time.timeScale = 1;
        ShowMain();
        LevelLoadInfo();
        
    }

    private void ShowLevelObjects()
    {
        for (var i = 0; i < _scenesInfo.Count; i++)
        {
            Debug.Log("Время " + i +" уровня: " + _scenesInfo[i].bestTime.text);
            _levelObjects[i].SetActive(_scenesInfo[i].bestTime.text != "none");
        }
    }
    
    private void Update()
    {
        ShowLevelObjects();
        CheckColorAudioSettings();
    }

    private void CheckColorAudioSettings()
    {
        _musicButtonText.color = AudioManager.Instance.musicOn ? Color.green : Color.red;
        _sfxButtonText.color = AudioManager.Instance.sfxOn ? Color.green : Color.red;
    }

    private void CheckAudioSettings()
    {
        if (PlayerPrefs.HasKey("SettingsMusicOn"))
        {
            AudioManager.Instance.musicOn = PlayerPrefs.GetInt("SettingsMusicOn") == 1;
        }
        else
        {
            AudioManager.Instance.musicOn = true;
        }

        if (PlayerPrefs.HasKey("SettingsSfxOn"))
        {
            AudioManager.Instance.sfxOn = PlayerPrefs.GetInt("SettingsSfxOn") == 1;
        }
        else
        {
            AudioManager.Instance.sfxOn = true;
        }
    }
    private void LevelLoadInfo()
    {
        foreach (var sceneInfo in _scenesInfo)
        {
            if (PlayerPrefs.HasKey(sceneInfo.nameOfScene + "time"))
            {
                sceneInfo.bestTime.text = PlayerPrefs.GetInt(sceneInfo.nameOfScene + "time").ToString();
            }
            else
            {
                sceneInfo.bestTime.text = "none";
            }
        }

        Zaserino();
    }

    private void Zaserino()
    {
        for (var i = 1; i < _scenesInfo.Count; i++)
        {
            _scenesInfo[i].unlocked = _scenesInfo[i - 1].bestTime.text != "none";
        }

        foreach (var sceneInfo in _scenesInfo)
        {
            sceneInfo.zaserino.SetActive(!sceneInfo.unlocked);
        }
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
        _sureCheckUI.SetActive(false);

    }

    public void ShowMain()
    {
        _mainUI.SetActive(true);
        _levelsUI.SetActive(false);
        _settingsUI.SetActive(false);
        _sureCheckUI.SetActive(false);

    }
    public void ShowSettings()
    {
        _mainUI.SetActive(false);
        _levelsUI.SetActive(false);
        _settingsUI.SetActive(true);
        _sureCheckUI.SetActive(false);
    }
    public void ShowSureCheck()
    {
        _mainUI.SetActive(false);
        _levelsUI.SetActive(false);
        _settingsUI.SetActive(false);
        _sureCheckUI.SetActive(true);
    }
    
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        CheckAudioSettings();
        LevelLoadInfo();
        ShowSettings();
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

    public void Exit()
    {
        Application.Quit();
    }
}