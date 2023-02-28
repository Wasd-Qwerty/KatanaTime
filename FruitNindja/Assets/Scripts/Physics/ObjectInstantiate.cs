using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Oculus.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private Transform[] _objectSpawnPos;

    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _throwAnimation;

    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private Vector3 _forceDirection;
    [SerializeField] private float _force;
    [SerializeField] private float _timeToDestroy = 4f;

    private Transform pos;
    
    private void Start()
    {
        pos = _objectSpawnPos[0];
        _animator = GetComponent<Animator>();
        _throwAnimation = FindAnimation(_animator, "ThrowCook");
    }

    public AnimationClip FindAnimation (Animator animator, string name) 
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
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
    
    public void Inst()
    {
        
        var fruitPrefab = _objects[Random.Range(0, _objects.Length)];
        var fruit = Instantiate(fruitPrefab, pos.position, Quaternion.identity);

        _rb = fruit.GetComponent<Rigidbody>();
        _rb.AddForce(_forceDirection * _force, _forceMode);

        Destroy(fruit, _timeToDestroy);
    }
}