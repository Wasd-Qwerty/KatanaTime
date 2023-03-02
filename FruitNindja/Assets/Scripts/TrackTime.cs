using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTime : MonoBehaviour
{
    [SerializeField] private float _timeInSecond = 10;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private Animator _cookAnimator;

    [SerializeField] private Text TimeText;

    void Start()
    {
        StartCoroutine("Track");
    }

    public void StopTrack()
    {
        StopCoroutine("Track");
    }

    private IEnumerator Track()
    {
        while (true)
        {
            _timeInSecond -= 1;
            TimeText.text = Convert.ToString(_timeInSecond);
            if (_timeInSecond == 0)
            {
                _menuManager.ShowWinUI();
                _cookAnimator.SetTrigger("win");
                break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}