using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteClyaksa : MonoBehaviour
{
    [SerializeField] private Image _clyaksa;
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
        clyaksaOnScreen = true;
        _clyaksa.color = new Color(255, 255, 255, 0.7f);
        var cacheA = _clyaksa.color.a;
        while (_clyaksa.color.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            cacheA -= 0.05f;
            print(_clyaksa.color);
            _clyaksa.color = new Color(255, 255, 255, cacheA);
        }

        _clyaksa.color = new Color(255, 255, 255, 0);
        clyaksaOnScreen = false;
    }
}