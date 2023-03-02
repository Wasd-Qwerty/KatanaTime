using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingObject : MonoBehaviour
{
    public Animator _stove;
    public Transform _forceTransform;
    private float _mindistance = 1;

    public bool _isBatting = false;
    public void Update()
    {
        if (_isBatting)
        {
            var position = transform.position;
            var targetPosition = _forceTransform.position;
            
            position = Vector3.MoveTowards(position, targetPosition, 0.4f);
            transform.position = position;
            
            if (Vector3.Distance(transform.position, targetPosition) < _mindistance)
            {
                
                _stove.SetTrigger("Burn");
                Destroy(this.gameObject);
            }
        }
    }

}
