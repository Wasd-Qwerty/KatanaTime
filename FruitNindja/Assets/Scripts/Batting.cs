using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Batting : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private double decreaseNumber = 50;
    private Vector3 _velocity;
    private float _minVelocity = 20f;

    [SerializeField] private Transform _forceTransform;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;
    
    
    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
            _velocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce((_forceTransform.position - transform.position) * _force, _forceMode);
        }
    }
}