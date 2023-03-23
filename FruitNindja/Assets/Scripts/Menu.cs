using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Screen;

    [Space]
    [SerializeField] private Animator TVAnimator;

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
    bool ispaused = false;
    void Changing_Afnimation()
    {
        ispaused = !ispaused;
    }

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
        if ((Input.GetKeyDown(KeyCode.Escape)) && notapause == false) Pause();
        if ((Input.GetKeyDown(KeyCode.Space)) && notapause == false) TVunactive();
        if (OVRInput.GetDown(OVRInput.Button.Three) && notapause == false)
        {
            Pause();
        }
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
        TVAnimator.Play("TVactive");
        ScreenActive();
        notapause = true;

        LoseScreen.SetActive(true);
        _changingHands.Death();
    }

    public void ShowWinUI()
    {
        TVAnimator.Play("TVactive");
        ScreenActive();
        notapause = true;

        WinScreen.SetActive(true);
        _scoreText.text = score.GetComponent<TextMeshProUGUI>().text;

        _changingHands.Death();
    }

    void Pause()
    {
        if (ispaused == false)
        {
            _changingHands.Death();
            if (!notapause)
            {
                Continue();
            }

            TVAnimator.Play("TVactive");
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
    }

    public void TVunactive()
    { 
        if(ispaused == true)
        {
            _changingHands.Death();

            TVAnimator.Play("TVunactive");
            ScreenUnActive();
            PauseScreen.SetActive(false);
        }
    }
    public void Continue()
    {
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
