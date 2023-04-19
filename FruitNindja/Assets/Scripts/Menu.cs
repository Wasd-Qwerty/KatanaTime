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
    [SerializeField] private TrackTime time;
    [SerializeField] private Text _timeText;

    [Space]
    [SerializeField] private CookController cookController;

    [Space]
    [SerializeField] private GameObject indicator;
    Material material;

    [Space]
    public Changing_Hands _changingHands;

    bool notapause = false;
    bool ispaused = false;

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
        AudioManager.Instance.PlayMusic("Lose"); 
        AudioManager.Instance.PlaySFX("LoseHurt"); 
        TVAnimator.Play("TVactive");
        ScreenActive();
        notapause = true;

        LoseScreen.SetActive(true);
        _changingHands.Death();
    }

    public void ShowWinUI()
    {
        AudioManager.Instance.PlaySFX("Win");
        TVAnimator.Play("TVactive");
        ScreenActive();
        notapause = true;

        WinScreen.SetActive(true);
        _timeText.text = time.timeInSecond.ToString();

        _changingHands.Death();
    }

    void Pause()
    {
        if (!ispaused)
        {
            ispaused = true;
            _changingHands.Death();

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
            TVAnimator.Play("TVunactive");
            ScreenUnActive();
            PauseScreen.SetActive(false);
        }
    }
    public void Continue()
    {
        ispaused = false;
        Time.timeScale = 1f;
        _changingHands.Death();
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
        AudioManager.Instance.PlayMusic("Theme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
