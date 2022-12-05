using System.Collections;
using UnityEngine;

public class BananaWalk : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _force;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_forceDirection * _force, _forceMode);
        Destroy(gameObject, 4f);
    }
}