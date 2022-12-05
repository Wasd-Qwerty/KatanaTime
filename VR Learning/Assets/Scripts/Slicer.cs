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
    [SerializeField] private float _blageLegth;

    [SerializeField] private Text _numberOfElementsCut;
    
    [SerializeField] private Transform explosionPosition;
    private void FixedUpdate()
    {
        var bounds = _collider.bounds;
        /*var colliders = Physics.OverlapBox(bounds.center, bounds.extents, _collider.transform.rotation, _slicablesMask, QueryTriggerInteraction.Collide);*/
        var hits = Physics.BoxCastAll(bounds.center,bounds.extents, (bounds.center - _startPoint.position), 
            _collider.transform.rotation, _blageLegth, _slicablesMask, QueryTriggerInteraction.Collide);
        Debug.DrawRay(bounds.center, bounds.center - _startPoint.position, Color.green);
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
