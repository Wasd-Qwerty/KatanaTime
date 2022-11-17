using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private LayerMask _slicablesMask;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _blageLegth;
    private void FixedUpdate()
    {
        var bounds = _collider.bounds;
        /*var colliders = Physics.OverlapBox(bounds.center, bounds.extents, _collider.transform.rotation, _slicablesMask, QueryTriggerInteraction.Collide);*/
        var hits = Physics.BoxCastAll(bounds.center,bounds.extents, (bounds.center - _startPoint.position), 
            _collider.transform.rotation, _blageLegth, _slicablesMask, QueryTriggerInteraction.Collide);
        
        if (hits.Length == 0)
        {
            return;
        }
        
        foreach (var hit in hits)
        {
            var slicable = hit.collider.GetComponent<SlicableItem>();
            slicable.Slice(hit.point);
        }
    }
}
