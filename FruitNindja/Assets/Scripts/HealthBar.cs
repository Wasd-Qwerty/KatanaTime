using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI health_txt;

    public int damage;
    private void Start()
    {
        health_txt.text = health.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            health = health - damage;
            health_txt.text = health.ToString();
        }
    }
}
