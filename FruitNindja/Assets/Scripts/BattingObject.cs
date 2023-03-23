using System;
using UnityEngine;

public class BattingObject : MonoBehaviour
{
    public Animator _stoveAnimator;
    public Vector3 _forcePos;
    private float _mindistance = 1;

    public bool _isBatting = false;
    private bool _isStoveAnimatorNotNull;
    private BeforeDestroy _beforeDestroy;

    private void Start()
    {
        _beforeDestroy = gameObject.GetComponent<BeforeDestroy>();
        _isStoveAnimatorNotNull = _stoveAnimator != null;
    }

    public void Update()
    {
        if (_isBatting)
        {
            var position = transform.position;

            position = Vector3.MoveTowards(position, _forcePos, 0.4f);
            transform.position = position;
            
            if (Vector3.Distance(transform.position, _forcePos) < _mindistance)
            {
                if (_isStoveAnimatorNotNull)
                {
                    _stoveAnimator.SetTrigger("Burn");
                }
                _beforeDestroy.DestroyObj(0);
            }
        }
    }

}
