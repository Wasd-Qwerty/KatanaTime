using System;
using System.Collections;
using UnityEngine;

public class Batting : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private double decreaseNumber = 100;
    [SerializeField] private Animator _stoveAnimator;
    [SerializeField] private Transform _forceTransform;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
            // AudioManager.Instance.PlaySFX("No");
        }
        else if ((inedibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            // AudioManager.Instance.PlaySFX("Yes");
        }

        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0 ||
            (inedibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            collision.gameObject.GetComponent<BattingObject>()._stoveAnimator = _stoveAnimator;
            collision.gameObject.GetComponent<BattingObject>()._forceTransform = _forceTransform;

            collision.gameObject.GetComponent<BattingObject>()._isBatting = true;
            Destroy(collision.gameObject.GetComponent<Collider>());
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}