using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

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
    }

    
}