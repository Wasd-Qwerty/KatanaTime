using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Screen;
    [Space]
    public GameObject PauseScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    [Space]
    public Button continueButton;
    public Button restartButton;
    public Button quitButton;

    [Space]
    [SerializeField] CookController cookController;

    [Space]
    [SerializeField] GameObject indicator;
    Material material;


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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Continue();
        }
    }
    
    void ScreenActive()
    {
        Screen.SetActive(true);
        material.color = Color.green;

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
    void Pause()
    {
        ScreenActive();
        PauseScreen.SetActive(true);
    }

    void Continue()
    {
        Screen.SetActive(false);
        PauseScreen.SetActive(false);
        material.color = Color.red;
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
        SceneManager.LoadScene("VTest");
    }

    void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
