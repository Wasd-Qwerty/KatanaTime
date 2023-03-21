using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")] [SerializeField] private List<SceneInfo> _scenesInfo;

    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _levelsUI;

    private Color[] Colors = 
     {
         Color.red,
         Color.green, 
         Color.blue, 
     };
    
    private void Start()
    {
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
    }

    Color CheckColorForEstimation(string estimation)
    {
        if (estimation == "none")
        {
            return Color.black;
        }
        if (estimation == "S")
        {
            return Colors[Random.Range(0,Colors.Length)];
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

    public void StartLevel()
    {
        _doorAnimator.SetTrigger("occurrence");
        gameObject.SetActive(false);
    }

    public void ShowLevels()
    {
        _mainUI.SetActive(false);
        _levelsUI.SetActive(true);
    }

    public void ShowMain()
    {
        _mainUI.SetActive(true);
        _levelsUI.SetActive(false);
    }
}