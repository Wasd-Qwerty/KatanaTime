using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slicer : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private LayerMask _slicablesMask;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _bladeLength;

    [SerializeField] private ScoreManager _scoreManager;

    [SerializeField] private Transform explosionPosition;
    
    // [SerializeField] private Transform _debugPoint;
    private Bounds _bounds;
    [SerializeField] private Vector3 _extents;
    private void Start()
    {
        _bounds = _collider.bounds;
        
    }

    private void FixedUpdate()
    {
        DebugDraw();
        WorkOfBoxCast();
    }

    private void WorkOfBoxCast()
    {
        _bounds = _collider.bounds;
        /*var colliders = Physics.OverlapBox(bounds.center, bounds.extents, _collider.transform.rotation, _slicablesMask, QueryTriggerInteraction.Collide);*/
        var hits = Physics.BoxCastAll(_bounds.center + transform.forward * 0.02f, _extents,
            (_bounds.center - _startPoint.position),
            _collider.transform.rotation, _bladeLength, _slicablesMask, QueryTriggerInteraction.Collide);

        if (hits.Length == 0)
        {
            return;
        }

        // foreach (var hit in hits)
        // {
        //     var slicable = hit.collider.GetComponent<SlicableMaterial>();
        //     slicable.Slice(explosionPosition.position);
        //     if (slicable.isFruit)
        //     {
        //         _scoreManager.IncreaseScore();
        //     }
        // }
    }

    private void DebugDraw()
    {
        // Debug.Log(_bounds.size.x / _extents.x + " : "  + _bounds.size.y / _extents.y + " : " + _bounds.size.z / _extents.z);
        // _debugPoint.position = _bounds.center;
        Debug.DrawRay(_startPoint.position, _bounds.center - _startPoint.position, Color.blue);
        ExtDebug.DrawBox(_bounds.center + transform.forward * 0.02f, _extents, _collider.transform.rotation,
            Color.blue);
    }
}