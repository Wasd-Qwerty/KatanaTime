using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class SpriteClyaksa : MonoBehaviour
{
    [SerializeField] private Image[] _blots;
    private bool clyaksaOnScreen;

    
    
    public void Sprite()
    {
        if (!clyaksaOnScreen)
        {
            StartCoroutine(Clyaksa());
        }
    }

    private IEnumerator Clyaksa()
    {
        Random rand = new Random();
        var blob = _blots[rand.Next(0, _blots.Length)];
        
        clyaksaOnScreen = true;
        blob.color = new Color(255, 255, 255, 0.7f);
        var cacheA = blob.color.a;
        while (blob.color.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            cacheA -= 0.05f;
            print(blob.color);
            blob.color = new Color(255, 255, 255, cacheA);
        }

        blob.color = new Color(255, 255, 255, 0);
        clyaksaOnScreen = false;
    }
}