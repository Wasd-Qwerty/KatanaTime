using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private Transform[] _objectSpawnPos;
    
    [CanBeNull] public TrackTime trackTime;
    
    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _force;
    [SerializeField] private float _timeToDestroy = 4f;
    [SerializeField] private float _timeToInst = 4f;

    private void Start()
    {
        StartCoroutine("Inst");
    }
    
    private IEnumerator Inst()
    {
        while (true)
        {
            if (trackTime != null) trackTime.timeInst = Time.time;
        
            var pos = _objectSpawnPos[Random.Range(0, _objectSpawnPos.Length)];
            var fruitPrefab = _objects[Random.Range(0, _objects.Length)];
            var fruit = Instantiate(fruitPrefab,pos.position, Quaternion.identity);
        
            _rb = fruit.GetComponent<Rigidbody>();
            _rb.AddForce(_forceDirection * _force, _forceMode);
        
            Destroy(fruit, _timeToDestroy);
            yield return new WaitForSeconds(_timeToInst);
        }
    }
}
