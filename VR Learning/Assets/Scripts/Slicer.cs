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
    
    
    [SerializeField] private Text _numberOfElementsCut;
    
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
        _bounds = _collider.bounds;
        /*var colliders = Physics.OverlapBox(bounds.center, bounds.extents, _collider.transform.rotation, _slicablesMask, QueryTriggerInteraction.Collide);*/
        var hits = Physics.BoxCastAll(_bounds.center - new Vector3(0,0.1f,0.1f), _extents, (_bounds.center - _startPoint.position), 
            _collider.transform.rotation, _bladeLength, _slicablesMask, QueryTriggerInteraction.Collide);
        Debug.Log(_bounds.size.x / _extents.x + " : "  + _bounds.size.y / _extents.y + " : " + _bounds.size.z / _extents.z);
        // _debugPoint.position = _bounds.center;
        Debug.DrawRay(_startPoint.position, _bounds.center - _startPoint.position, Color.blue);
        ExtDebug.DrawBox(_bounds.center - new Vector3(0,0.01f,0.01f), _extents, _collider.transform.rotation, Color.blue);
        if (hits.Length == 0)
        {
            return;
        }
        foreach (var hit in hits)
        {
            var slicable = hit.collider.GetComponent<SlicableItem>();
            var cacheCount = Convert.ToInt32(_numberOfElementsCut.text); 
            slicable.Slice(explosionPosition.position);
            _numberOfElementsCut.text = Convert.ToString(cacheCount + 1);
        }
    }
}
