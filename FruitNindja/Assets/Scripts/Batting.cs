using System;
using System.Collections;
using UnityEngine;

public class Batting : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private int decreaseNumber = 100;
    [SerializeField] private Animator _stoveAnimator;
    [SerializeField] private Transform _forceTransform;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    [SerializeField] private int _levelIndex;

    private void OnTriggerEnter(Collider collider)
    {
        if ((edibleLayer & (1 << collider.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
        }
        if ((edibleLayer & (1 << collider.gameObject.layer)) == 0 &&
            (inedibleLayer & (1 << collider.gameObject.layer)) == 0) return;
        
        collider.gameObject.GetComponent<BattingObject>()._stoveAnimator = _stoveAnimator;
        collider.gameObject.GetComponent<BattingObject>()._forcePos = _forceTransform.position;
            
        collider.gameObject.GetComponent<BattingObject>()._isBatting = true;
        Destroy(collider.gameObject.GetComponent<Collider>());
        collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        switch (_levelIndex)
        {
            case 1:
                AudioManager.Instance.PlaySFX("Skovorodka");
                break;
            case 2:
                AudioManager.Instance.PlaySFX("Doska");
                break;
        }
    }
}