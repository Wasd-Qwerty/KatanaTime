using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public GameObject health_txt_gameObject;
    public TextMesh health_txt;

    public int damage;
    private void Start()
    {
        health_txt.text = health.ToString();
        health_txt_gameObject.GetComponent<TextMesh>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "NFruit")
        {
            health = health - damage;
            health_txt.text = health.ToString();
        }
    }
}
