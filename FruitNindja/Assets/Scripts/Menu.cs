using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Screen;

    [Space]
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;

    [Space]
    [SerializeField] private GameObject score;
    [SerializeField] private Text _scoreText;

    [Space]
    [SerializeField] private CookController cookController;

    [Space]
    [SerializeField] private GameObject indicator;
    Material material;

    [Space]
    public Changing_Hands _changingHands;

    bool notapause = false;


    void Start()
    {
        Screen.SetActive(false);
        PauseScreen.SetActive(false);
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);

        Renderer renderer = indicator.GetComponent<Renderer>();
        material = renderer.material;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three) && notapause == false)
        {
            Pause();
        }
        // if (OVRInput.GetDown(OVRInput.Button.Four))
        // {
        //     Continue();
        // }
    }

    void ScreenActive()
    {
        Screen.SetActive(true);
        material.color = Color.green;
    }
    void ScreenUnActive()
    {
        Screen.SetActive(false);
        material.color = Color.red;
    }

    public void ShowGameOverUI()
    {
        ScreenActive();
        notapause = true;

        LoseScreen.SetActive(true);
        _changingHands.Death();
    }

    public void ShowWinUI()
    {
        ScreenActive();
        notapause = true;
        _scoreText.text = score.GetComponent<TextMeshProUGUI>().text;

        WinScreen.SetActive(true);
        _changingHands.Death();
    }

    void Pause()
    {
        ScreenActive();
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        try
        {
            foreach (var obj in cookController.objectsOnScene)
            {
                Rotation_Physics rotation_Physics = obj.GetComponent<Rotation_Physics>();
                if (rotation_Physics != null)
                {
                    rotation_Physics.enabled = false;
                }
            }
        }
        catch
        {
            foreach (var obj in cookController.objectsOnScene)
            {
                if (obj != null)
                {
                    Rotation_Physics rotation_Physics = obj.GetComponent<Rotation_Physics>();
                    if (rotation_Physics != null)
                    {
                        rotation_Physics.enabled = false;
                    }
                }
            }
        }
    }

    public void Continue()
    {
        ScreenUnActive();
        Time.timeScale = 1f;
        try
        {
            foreach (var obj in cookController.objectsOnScene)
            {
                Rotation_Physics rotation_Physics = obj.GetComponent<Rotation_Physics>();
                if (rotation_Physics != null)
                {
                    rotation_Physics.enabled = true;
                }
            }
        }
        catch
        {
            foreach (var obj in cookController.objectsOnScene)
            {
                if (obj != null)
                {
                    Rotation_Physics rotation_Physics = obj.GetComponent<Rotation_Physics>();
                    if (rotation_Physics != null)
                    {
                        rotation_Physics.enabled = true;
                    }
                }
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
