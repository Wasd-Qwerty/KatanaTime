using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _scoreText;
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
        var cacheScore = _score.GetComponent<Text>().text;
        _winScore.GetComponent<Text>().text = cacheScore;

        _scoreText.SetActive(false);
        _score.SetActive(false);
        _winUI.SetActive(true);
        _changingHands.Death();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
