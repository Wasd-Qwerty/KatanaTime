using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private float _explosionForce = 2f;
    [SerializeField] private float _explosionRadius = 1f;
    [SerializeField] private float _explosionUpwardsModifier;
    [SerializeField] private ForceMode _explosionForceMode;
    
    public void Slice(Vector3 slicePosition)
    {
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<Rigidbody>());
        foreach (var part in _parts)
        {
            part.isKinematic = false;
            part.AddExplosionForce(_explosionForce, slicePosition, _explosionRadius, _explosionUpwardsModifier, _explosionForceMode);
        }    
        Destroy(gameObject, 3f);
    }
}
