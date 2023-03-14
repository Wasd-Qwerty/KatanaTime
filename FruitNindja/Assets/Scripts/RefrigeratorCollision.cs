using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrigeratorCollision : MonoBehaviour
{
    private Menu _menu;

    private void Start()
    {
        _menu = GameObject.FindWithTag("TV").GetComponent<Menu>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Fridge"))
        {
            _menu.ShowGameOverUI();
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}