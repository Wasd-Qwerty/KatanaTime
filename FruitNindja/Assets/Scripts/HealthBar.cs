using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI health_txt_right;
    public TextMeshProUGUI health_txt_left;

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
            if (health == 0)
            {
                _cookAnimator.SetTrigger("gameOver");
            }
        }
        health_txt_right.text = health.ToString();
        health_txt_left.text = health.ToString();
    }
}
