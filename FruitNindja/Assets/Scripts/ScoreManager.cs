using System;
using System.Globalization;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private CookController _cookController;
    public int countOfSlicedObjects = 0;
    
    public string estimation = "S";
    
    private void Update()
    {
        CalculateEstimation();
    }

    private void CalculateEstimation()
    {
        var percentOfSlice = countOfSlicedObjects / _cookController.maxCountOfEdible * 100;
        if (percentOfSlice > 99)
        {
            // превосходно
            estimation = "S";
        }
        else if (percentOfSlice > 89)
        {
            // отлично
            estimation = "A";
        }
        else if(percentOfSlice > 79)
        {
            // хорошо
            estimation = "B";
        }
        else if (percentOfSlice > 69)
        {
            // удовлетворительно
            estimation = "C";
        }
        else if(percentOfSlice > 59)
        {
            // достаточно (проходной балл)
            estimation = "D";
        }
        else
        {
            // Миша, всё хуйня - давай по новой
            estimation = "E";
        }
    }

    public void Death()
    {
        Debug.Log("Помер. Ваша оценка: " + estimation);
    }
    
    public void IncreaseScore(double editNumber)
    {
        var cacheScore = Convert.ToDouble(_scoreText.text);
        _scoreText.text = Convert.ToString(cacheScore + editNumber, CultureInfo.InvariantCulture);
    }

    public void DecreaseScore(double editNumber)
    {
        var cacheScore = Convert.ToDouble(_scoreText.text);
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