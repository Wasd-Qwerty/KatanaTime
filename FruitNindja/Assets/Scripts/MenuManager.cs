using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _winScore;
    
    [SerializeField] private Changing_Hands _changingHands;

    private void Start()
    {
        _gameOverUI.SetActive(false);
        _winUI.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        _gameOverUI.SetActive(true);
        _changingHands.Death();
    }

    public void ShowWinUI()
    {
        _winScore.GetComponent<Text>().text = _scoreText.text;

        _winUI.SetActive(true);
        _changingHands.Death();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}