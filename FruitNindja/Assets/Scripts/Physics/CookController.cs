using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Oculus.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

public class CookController : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] public List<GameObject> objectsOnScene;
    
    [SerializeField] private Transform[] _objectSpawnPos;

    [SerializeField] private Animator _animator;

    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private List<Vector3> _forceDirections;
    [SerializeField] private float _force;
    [SerializeField] private float _timeToDestroy = 4f;

    private bool _leftHand;
    private Transform pos;
    
    [SerializeField] private MenuManager _menuManager;
    
    private void Start()
    {
        pos = _objectSpawnPos[0];
        _animator = GetComponent<Animator>();
        _leftHand = _animator.GetBool("LeftHand");
    }

    private void Update()
    {
        foreach (var obj in objectsOnScene)
        {
            if (obj == null)
            {
                objectsOnScene.Remove(obj);
                break;
            }
        }
    }

    public void RandomizeNextPosition()
    {
        var randomIndexPos = Random.Range(0, _objectSpawnPos.Length);

        if (randomIndexPos == 0)
        {
            _animator.SetBool("LeftHand", false);
        }
        else
        {
            _animator.SetBool("LeftHand", true);
        }

        pos = _objectSpawnPos[randomIndexPos];
    }
    
    public void InstantiateAnObject()
    {
        
        var fruitPrefab = _objects[Random.Range(0, _objects.Length)];
        var fruit = Instantiate(fruitPrefab, pos.position, Quaternion.identity);

        _rb = fruit.GetComponent<Rigidbody>();
        _rb.AddForce(_forceDirections[0] * _force, _forceMode);
        objectsOnScene.Add(fruit);
        Destroy(fruit, _timeToDestroy);
    }

    public void ShowGameOver()
    {
        _menuManager.ShowGameOverUI();
    }
}