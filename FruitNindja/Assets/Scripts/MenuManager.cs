using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private Changing_Hands _changingHands;
    private void Start()
    {
        _gameOverUI.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
        _changingHands.Death();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
