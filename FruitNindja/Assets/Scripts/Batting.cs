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

    private void OnCollisionEnter(Collision collision)
    {
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
        }
        if ((edibleLayer & (1 << collision.gameObject.layer)) == 0 &&
            (inedibleLayer & (1 << collision.gameObject.layer)) == 0) return;
        
        collision.gameObject.GetComponent<BattingObject>()._stoveAnimator = _stoveAnimator;
        collision.gameObject.GetComponent<BattingObject>()._forcePos = _forceTransform.position;
            
        collision.gameObject.GetComponent<BattingObject>()._isBatting = true;
        Destroy(collision.gameObject.GetComponent<Collider>());
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
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