using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private HealthBar _healthBar;
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