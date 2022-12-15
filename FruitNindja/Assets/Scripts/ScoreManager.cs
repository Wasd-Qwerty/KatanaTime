using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _numberOfElementsCut;

    public void IncreaseScore()
    {
        var cacheCount = Convert.ToInt32(_numberOfElementsCut.text); 
        _numberOfElementsCut.text = Convert.ToString(cacheCount + 1);
    }
}
