using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrigeratorCollision : MonoBehaviour
{
    private MenuManager _menuManager;

    private void Start()
    {
        _menuManager = GameObject.FindWithTag("MenuManager").GetComponent<MenuManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Fridge"))
        {
            Debug.Log("Хуяк");
            _menuManager.ShowGameOverUI();
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}