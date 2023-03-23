using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CookController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsPrefabs;
    public List<GameObject> objectsOnScene;

    public float maxCountOfEdible = 80;
    
    public int countOfEdible = 0;
    private int countOfInedible = 0;

    public bool needOnlyEdible;
    
    [SerializeField] private Transform[] _objectSpawnPos;

    [SerializeField] private Animator _animator;

    private Rigidbody _rb;
    [SerializeField] private List<Vector3> _forceDirections;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _force;
    [SerializeField] private float _timeToDestroy = 4f;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;
    
    private Transform pos;
    
    
    
    private void Start()
    {
        pos = _objectSpawnPos[0];
        _animator = GetComponent<Animator>();
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
        if (_objectsPrefabs.Count == 0)
        {
            return;
        }

        GameObject objectForInst;
        
        var randomIndexPos = Random.Range(0, _objectsPrefabs.Count);
        var objectPrefab = _objectsPrefabs[randomIndexPos];
        if (needOnlyEdible)
        {
            if (countOfEdible == maxCountOfEdible)
            {
                needOnlyEdible = false;
                InstantiateAnObject();
                return;
            }
            while ((inedibleLayer & (1 << objectPrefab.gameObject.layer)) != 0)
            {
                randomIndexPos = Random.Range(0, _objectsPrefabs.Count);
                objectPrefab = _objectsPrefabs[randomIndexPos];
            }
            if ((edibleLayer & (1 << objectPrefab.gameObject.layer)) != 0)
            {
                countOfEdible++;
                Debug.Log("Съедобно: " + countOfEdible);
            }
            objectForInst = Instantiate(objectPrefab, pos.position, Quaternion.identity);
        }
        else
        {
            if (countOfEdible == maxCountOfEdible)
            {
                while ((edibleLayer & (1 << objectPrefab.gameObject.layer)) != 0)
                {
                    randomIndexPos = Random.Range(0, _objectsPrefabs.Count);
                    objectPrefab = _objectsPrefabs[randomIndexPos];
                }
            }
            if ((edibleLayer & (1 << objectPrefab.gameObject.layer)) != 0)
            {
                countOfEdible++;
                Debug.Log("Съедобно: " + countOfEdible);
            }
            if ((inedibleLayer & (1 << objectPrefab.gameObject.layer)) != 0)
            {
                countOfInedible++;
                Debug.Log("Несъедобно: " + countOfInedible);
            }
            objectForInst = Instantiate(objectPrefab, pos.position, Quaternion.identity);
        }
        
        _rb = objectForInst.GetComponent<Rigidbody>();
        _rb.AddForce(_forceDirections[0] * _force, _forceMode);
        objectsOnScene.Add(objectForInst);
        objectForInst.AddComponent<BeforeDestroy>().DestroyObj(_timeToDestroy);
    }

    

    
}