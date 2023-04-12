using System;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public SlicerMeshes slicer;

    
    private BoxCollider _boxCollider;

    [SerializeField] private float _angularOfSlice = 45;
    
    [SerializeField] private Transform _startPoint;
    public LayerMask layerMask;
    public float maxDistance = 1;
    [SerializeField] private Vector3 _extents = new Vector3(0.1f, 1f, 0.1f);
   
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }


    private void FixedUpdate()
    {
        DebugDraw();

        var direction = transform.up;
        var hits = Physics.BoxCastAll(_boxCollider.bounds.center, _extents, direction, _boxCollider.transform.rotation, maxDistance, layerMask, QueryTriggerInteraction.Ignore);
        foreach (var hit in hits)
        {
            if ((transform.rotation.eulerAngles.y > -_angularOfSlice && transform.eulerAngles.y < _angularOfSlice) || transform.rotation.eulerAngles.y - 360 > -_angularOfSlice && transform.eulerAngles.y - 360 < _angularOfSlice)
            {
                slicer.Touch();          
            }
        }
    }

    private void DebugDraw()
    {
        ExtDebug.DrawBox(_boxCollider.bounds.center, _extents, _boxCollider.transform.rotation,
            Color.blue);
    }
}
