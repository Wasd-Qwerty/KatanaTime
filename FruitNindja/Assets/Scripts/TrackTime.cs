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
    
    [Header("Time Scroller")]
    
    [SerializeField] private GameObject _timeScroller;
    [SerializeField] private GameObject _timePoint;

    [SerializeField] private float _minPointPos;
    [SerializeField] private float _maxPointPos;
    [SerializeField] private float _minScrollerScale;
    [SerializeField] private float _maxScrollerScale;

    public float variable1 = 0;
    public float variable2 = 0;

    void Update()
    {
        // Calculate the value of variable2 based on the value of variable1
        variable2 = (-0.008f * variable1) + 0.85f;

        // Print the values of the variables for testing
        Debug.Log("Variable1: " + variable1);
        Debug.Log("Variable2: " + variable2);
    }

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