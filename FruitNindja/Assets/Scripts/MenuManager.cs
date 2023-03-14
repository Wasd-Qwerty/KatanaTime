using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator; 
    [SerializeField] private GameObject _mainUI; 
    [SerializeField] private GameObject _levelsUI;

    private void Start()
    {
        ShowMain();
    }

    public void StartLevel()
    {
        _doorAnimator.SetTrigger("occurrence");
        _mainUI.SetActive(false);
        _levelsUI.SetActive(false);
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