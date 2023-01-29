using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTime : MonoBehaviour
{
    public float timeInst;
    public float flightTime;
    [SerializeField] private LayerMask sliceLayer;
    private void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & sliceLayer) != 0)
        {
            var timeNow = Time.time;
            flightTime = timeNow - timeInst;
        }
    }
}
