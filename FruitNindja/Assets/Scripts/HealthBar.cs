using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI health_txt_right;
    public TextMeshProUGUI health_txt_left;
    [SerializeField] private TrackTime _trackTime;
    
    [SerializeField] private Animator _cookAnimator;

    public int damage;

    private void Start()
    {
        health_txt_right.text = health.ToString();
        health_txt_left.text = health.ToString();
    }

    public void Damage()
    {
        if (health > 0)
        {
            health -= damage;
            AudioManager.Instance.PlaySFX("Hurt");
            if (health == 0)
            {
                _trackTime.StopTrack();
                Death();
            }
        }

        health_txt_right.text = health.ToString();
        health_txt_left.text = health.ToString();
    }

    private void Death()
    {
        _cookAnimator.SetTrigger("gameOver");
    }
}