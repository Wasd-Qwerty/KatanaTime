using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Batting : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    private int decreaseNumber = 100;
    [SerializeField] private Animator _stoveAnimator;
    [SerializeField] private Transform _forceTransform;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    [SerializeField] private int _levelIndex;
    

    private void OnTriggerEnter(Collider collider)
    {
        if ((edibleLayer & (1 << collider.gameObject.layer)) == 0 &&
            (inedibleLayer & (1 << collider.gameObject.layer)) == 0) return;
        
        if ((edibleLayer & (1 << collider.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
        }

        GameObject _colObj = collider.gameObject;
        BattingObject _battingObject = _colObj.GetComponent<BattingObject>();

        if (_battingObject._isSliced)
        {
            return;
        }
        _battingObject._stoveAnimator = _stoveAnimator;
        _battingObject._forcePos = _forceTransform.position;
            
        _battingObject._isBatting = true;
        _colObj.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(_colObj.GetComponent<Collider>());
        switch (_levelIndex)
        {
            case 1:
                AudioManager.Instance.PlaySFX("Skovorodka");
                break;
            case 2:
                AudioManager.Instance.PlaySFX("Doska");
                break;
            case 3:
                AudioManager.Instance.PlaySFX("Doska");
                break;
        }
    }
}