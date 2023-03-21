using System;
using System.Globalization;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _estimationText;
    [SerializeField] private HealthBar _healthBar;

    public int countOfEdible;
    public LayerMask edibleLayer;

    [SerializeField] private CookController _cookController;
    
    private string estimation = "S";
    
    private void Update()
    {
        _estimationText.text = estimation;
        CalculateEstimation();
    }

    private void CalculateEstimation()
    {
        var cacheScore = Convert.ToDouble(_scoreText.text);
        if (countOfEdible == 0)
        {
            estimation = "S";
            return;
        }
        
        var percentOfSlice = cacheScore / (countOfEdible * 100) * 100;
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
        else
        {
            // Миша, всё хуйня - давай по новой
            estimation = "C";
        }
    }

    public void Death()
    {
        string[] estimations = new[] { "S", "A", "B", "C"};
        var sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        var score = Convert.ToInt32(_scoreText.text);
        if (PlayerPrefs.HasKey(sceneName + "BestScore"))
        {
            if (PlayerPrefs.GetInt(sceneName + "BestScore") < score)
            {
                PlayerPrefs.SetInt(sceneName + "BestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt(sceneName + "BestScore", score);
        }

        int oldIndexEstimation = 0;
        int newIndexEstimation = 0;
        for (int i = 0; i < estimations.Length; i++)
        {
            if (estimations[i] == estimation)
            {
                newIndexEstimation = i;
            }

            if (PlayerPrefs.HasKey(sceneName + "Estimation") && PlayerPrefs.GetString(sceneName + "Estimation") == estimations[i])
            {
                oldIndexEstimation = i;
            }
        }
        
        if (PlayerPrefs.HasKey(sceneName + "Estimation"))
        {
            if (newIndexEstimation < oldIndexEstimation)
            {
                PlayerPrefs.SetString(sceneName + "Estimation", estimations[newIndexEstimation]);
            }
        }
        else
        {
            PlayerPrefs.SetString(sceneName + "Estimation", estimations[newIndexEstimation]);
        }
        
        PlayerPrefs.Save();
    }
    
    public void IncreaseScore(int editNumber)
    {
        var cacheScore = Convert.ToInt32(_scoreText.text);
        _scoreText.text = Convert.ToString(cacheScore + editNumber, CultureInfo.InvariantCulture);
    }

    public void DecreaseScore(int editNumber)
    {
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