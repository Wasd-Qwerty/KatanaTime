using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void AboutUs()
    {
        Debug.Log("Сделал Артёмка");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
