using System;
using System.Globalization;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _needScoreText;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Menu _menu;
    [SerializeField] private Animator _cookAnimator;
    [SerializeField] private TrackTime _trackTime;
    [SerializeField] private int _needScore;
    
    [Header("Score Scroller")]
    
    [SerializeField] private GameObject _timeScroller;
    [SerializeField] private GameObject _timePoint;

    [SerializeField] private float _minPointPos;
    [SerializeField] private float _maxPointPos;
    [SerializeField] private float _minScrollerScale;
    [SerializeField] private float _maxScrollerScale;

    private bool isWin;
    private void Start()
    {
        _needScoreText.text = _needScore.ToString();
    }

    private void Update()
    {
        if (isWin)
        {
            _scoreText.text = "win";
            return;
        }
        var cacheScore = Convert.ToInt32(_scoreText.text);
        if (cacheScore == _needScore)
        {
            _trackTime.StopTrack();
            _menu.ShowWinUI();
            _cookAnimator.SetTrigger("win");
            isWin = true;
        }

        if (cacheScore > _needScore)
        {
            cacheScore = _needScore;
            _scoreText.text = cacheScore.ToString();
        }
        Debug.Log(cacheScore);
        var posX = ((_maxPointPos - _minPointPos) * ((cacheScore/100f) / (_needScore/100f))) + _minPointPos;
            
        var pointPosition = _timePoint.transform.position;
        pointPosition = new Vector3(posX, pointPosition.y, pointPosition.z);
        _timePoint.transform.position = pointPosition;

            
        var scaleY = ((_maxScrollerScale - _minScrollerScale ) * ((cacheScore/100f) / (_needScore/100f))) + _minScrollerScale;
        
        var localScale = _timeScroller.transform.localScale;
        localScale = new Vector3(localScale.x, scaleY ,localScale.z);
        _timeScroller.transform.localScale = localScale;

    }

    public void IncreaseScore(int editNumber)
    {
        var cacheScore = Convert.ToInt32(_scoreText.text);
        _scoreText.text = Convert.ToString(cacheScore + editNumber, CultureInfo.InvariantCulture);
        Debug.Log("Прибавил");
    }

    public void DecreaseScore(int editNumber)
    {
        Debug.Log("Убавил");
        var cacheScore = Convert.ToInt32(_scoreText.text);
        if (cacheScore - editNumber >= 0)
        {
            _scoreText.text = Convert.ToString(cacheScore - editNumber, CultureInfo.InvariantCulture);
        }
        else
        {
            _healthBar.Damage();
        }
    }
}