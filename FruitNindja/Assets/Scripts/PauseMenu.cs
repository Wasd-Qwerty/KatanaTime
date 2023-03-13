using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
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
        pauseMenu.SetActive(false);
        continueButton.onClick.AddListener(Continue);
        restartButton.onClick.AddListener(Restart);
        quitButton.onClick.AddListener(Quit);

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

    void Pause()
    {
        pauseMenu.SetActive(true);
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

    void Continue()
    {
        pauseMenu.SetActive(false);
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

    void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Quit()
    {
        Application.Quit();
    }
}
