using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTime : MonoBehaviour
{
    [SerializeField] private float _timeInSecond = 120;
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
        var maxTime = _timeInSecond;
        while (true)
        {
            _timeInSecond -= 1;
            var posX = ((_minPointPos - _maxPointPos) * (_timeInSecond / maxTime)) + _maxPointPos;
            
            var pointPosition = _timePoint.transform.position;
            pointPosition = new Vector3(posX, pointPosition.y, pointPosition.z);
            _timePoint.transform.position = pointPosition;

            Debug.Log(pointPosition + " " + _timePoint.transform.position);
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