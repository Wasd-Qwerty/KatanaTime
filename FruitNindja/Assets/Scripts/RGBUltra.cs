using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RGBUltra : MonoBehaviour
{
    private SkinnedMeshRenderer _meshRenderer;

    private Color[] Colors = new Color[]
    {
        Color.black,
        Color.white,
    };
// private Color[] Colors = new Color[]
//     {
//         Color.red,
//         Color.yellow,
//         Color.green, 
//         Color.blue, 
//         Color.magenta,
//         Color.cyan
//     };

    void Start()
    {
        _meshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        _meshRenderer.material.color = Colors[Random.Range(0, Colors.Length)];
    }
}