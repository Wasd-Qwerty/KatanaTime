using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlicableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _parts;
    [SerializeField] private float _explosionForce = 2f;
    [SerializeField] private float _explosionRadius = 1f;
    [SerializeField] private float _explosionUpwardsModifier;
    [SerializeField] private ForceMode _explosionForceMode;
    private Camera _cam;
    private SpriteClyaksa _spriteClyaksa;
    private void Start()
    {
        _cam = Camera.main;
        _spriteClyaksa = GameObject.FindWithTag("SpriteClyaksa").GetComponent<SpriteClyaksa>();
    }

    public void Slice(Vector3 explosionPosition)
    {
        var distance = Vector3.Distance(transform.position, _cam.transform.position);
        if (distance < 10)
        {
            _spriteClyaksa.Sprite();
        }

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<Rigidbody>());
        foreach (var part in _parts)
        {
            part.isKinematic = false;
            part.GetComponent<BoxCollider>().isTrigger = false;
            part.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, _explosionUpwardsModifier,
                _explosionForceMode);
        }

        Destroy(gameObject, 3f);
    }

   
}
    