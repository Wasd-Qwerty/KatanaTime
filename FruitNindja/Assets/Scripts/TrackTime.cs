using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TrackTime : MonoBehaviour
{
    [SerializeField] private float _timeInSecond = 120;
    [SerializeField] private Menu _menu;
    [SerializeField] private GameObject _cook;
    private CookController _cookController;
    private Animator _cookAnimator;

    [SerializeField] private TextMeshProUGUI timeText;
    
    [Header("Time Scroller")]
    
    [SerializeField] private GameObject _timeScroller;
    [SerializeField] private GameObject _timePoint;

    [SerializeField] private float _minPointPos;
    [SerializeField] private float _maxPointPos;
    [SerializeField] private float _minScrollerScale;
    [SerializeField] private float _maxScrollerScale;

    [SerializeField] private ScoreManager _scoreManager;
    void Start()
    {
        _cookController = _cook.GetComponent<CookController>();
        _cookAnimator = _cook.GetComponent<Animator>();
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
            timeText.text = Convert.ToString(_timeInSecond);

            if (_timeInSecond < 20 && _cookController.countOfEdible != _cookController.maxCountOfEdible)
            {
                _cookController.needOnlyEdible = true;
            }
            
            var posX = ((_minPointPos - _maxPointPos) * (_timeInSecond / maxTime)) + _maxPointPos;
            
            var pointPosition = _timePoint.transform.position;
            pointPosition = new Vector3(posX, pointPosition.y, pointPosition.z);
            _timePoint.transform.position = pointPosition;

            
            var scaleY = ((_minScrollerScale - _maxScrollerScale) * (_timeInSecond / maxTime)) + _maxScrollerScale;
           
            var localScale = _timeScroller.transform.localScale;
            localScale = new Vector3(localScale.x, scaleY ,localScale.z);
            _timeScroller.transform.localScale = localScale;

            
            if (_timeInSecond <= 0)
            {
                _menu.ShowWinUI();
                _cookAnimator.SetTrigger("win");
                _scoreManager.Death();
                break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}