using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public SlicerMeshes slicer;
    
    private BoxCollider _boxCollider;

    [SerializeField] private Transform _startPoint;
    public LayerMask layerMask;
    public float maxDistance = 1;
    [SerializeField] private Vector3 _extents = new Vector3(0.1f, 1f, 0.1f);
    [SerializeField] private Transform _directionDebug;
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     slicer.Touch();
    // }
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        DebugDraw();
        var direction = transform.up;
        _directionDebug.position = direction;
        // Debug.Log("Direction: " + direction);
        var hits = Physics.BoxCastAll(_boxCollider.bounds.center, _extents, direction, _boxCollider.transform.rotation, maxDistance, layerMask, QueryTriggerInteraction.Ignore);
        foreach (var hit in hits)
        {
            Debug.Log("Ok let`s go");
            slicer.Touch();
        }
        // try
        // {
        //     
        // }
        // catch (Exception e)
        // {
        //     Debug.Log(e.Message);
        //     Debug.Break();
        // }
    }
    private void DebugDraw()
    {
        ExtDebug.DrawBox(_boxCollider.bounds.center, _extents, _boxCollider.transform.rotation,
            Color.blue);
    }
}
