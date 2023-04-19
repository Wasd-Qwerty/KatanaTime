using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TrackTime : MonoBehaviour
{
    public float timeInSecond = 0;
    [SerializeField] private Menu _menu;
    [SerializeField] private GameObject _cook;
    private Animator _cookAnimator;

    void Start()
    {
        _cookAnimator = _cook.GetComponent<Animator>();
        StartCoroutine("Track");
    }

    public void StopTrack()
    {
        StopCoroutine("Track");
        Death();
    }

    private void Death()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var time = Convert.ToInt32(timeInSecond);
        if (PlayerPrefs.HasKey(sceneName + "time"))
        {
            if (PlayerPrefs.GetInt(sceneName + "time") > time)
            {
                PlayerPrefs.SetInt(sceneName + "time", time);
            }
        }
        else
        {
            PlayerPrefs.SetInt(sceneName + "time", time);
        }
        PlayerPrefs.Save();
    }
    private IEnumerator Track()
    {
        while (true)
        {
            timeInSecond += 1;
            
            if (timeInSecond <= 0)
            {
                _menu.ShowWinUI();
                _cookAnimator.SetTrigger("win");
                break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}