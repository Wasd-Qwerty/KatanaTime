using UnityEngine;

public class Batting : MonoBehaviour
{
    [SerializeField] private bool useIt;
    
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private double decreaseNumber = 50;
    

    [SerializeField] private Transform _forceTransform;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;


    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0 && useIt)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
        }
        collision.gameObject.GetComponent<Rigidbody>().AddForce((_forceTransform.position - transform.position) * _force, _forceMode);
    }
}