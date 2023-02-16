using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlshatZaebal : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;
    [SerializeField] private List<Vector3> _targetPoints;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        transform.LookAt(_targetPoints[Random.Range(0, _targetPoints.Count)]);
        _rb.AddForce(transform.forward * _force, _forceMode);
        Destroy(gameObject, 4f);
    }
}
