using System;
using System.Collections;
using UnityEngine;

public class Batting : MonoBehaviour
{
    
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private double decreaseNumber = 50;
    

    [SerializeField] private Transform _forceTransform;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;

    private float _mindistance = 1;
    

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;

    private void OnCollisionEnter(Collision collision)
    {
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            _scoreManager.DecreaseScore(decreaseNumber);
        }
        if ((edibleLayer & (1 << collision.gameObject.layer)) != 0 || (inedibleLayer & (1 << collision.gameObject.layer)) != 0)
        {
            StartCoroutine("BattingObject", collision.gameObject);
            collision.gameObject.GetComponent<Collider>().isTrigger = true;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            // collision.gameObject.GetComponent<Rigidbody>().AddForce((_forceTransform.position - transform.position) * _force, _forceMode);
        }
    }

    private IEnumerator BattingObject(GameObject _object)
    {
        while (true)
        {
            if (_object != null) 
            {
                var position = _object.transform.position;
                var targetPosition = _forceTransform.position;
            
                position = Vector3.MoveTowards(position, targetPosition, 0.4f);
                _object.transform.position = position;
            
                if (Vector3.Distance(_object.transform.position, targetPosition) < _mindistance)
                {
                    // долетел
                
                    Destroy(_object);
                    break;
                }
                yield return new WaitForSeconds(1/60f);
            }
        }
    }
}