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

    public int damage;
    private void Start()
    {
        health_txt_right.text = health.ToString();
        health_txt_left.text = health.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Damage();
    }
    public void Damage()
    {
        health = health - damage;
        health_txt_right.text = health.ToString();
        health_txt_left.text = health.ToString();
    }
}
