using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_Hands : MonoBehaviour
{
    [SerializeField] GameObject left_hand_knife;
    [SerializeField] GameObject left_hand_pan;
    [SerializeField] GameObject right_hand_knife;
    [SerializeField] GameObject right_hand_pan;

    [Header("Руки смерти")] 

    [SerializeField] private GameObject leftDiedHand;
    [SerializeField] private GameObject rightDiedHand;

    public bool pauseGame;
    public GameObject pauseGameMenu;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;
    [SerializeField]CookController cookController;

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
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
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
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
                if(obj != null)
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
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(0);
    }

    private void Update()
    {
        Changing();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGame) Resume();
            else Pause();
        }
    }

    void Changing()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Touch))
        {
            left_hand_knife.SetActive(false);
            right_hand_knife.SetActive(true);
            left_hand_pan.SetActive(true);
            right_hand_pan.SetActive(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
        {
            left_hand_knife.SetActive(true);
            right_hand_knife.SetActive(false);
            left_hand_pan.SetActive(false);
            right_hand_pan.SetActive(true);
        }
    }

    public void Death()
    {
        left_hand_knife.SetActive(false);
        right_hand_knife.SetActive(false);
        left_hand_pan.SetActive(false);
        right_hand_pan.SetActive(false);
        leftDiedHand.SetActive(true);
        rightDiedHand.SetActive(true);
        Destroy(this);
    }
}