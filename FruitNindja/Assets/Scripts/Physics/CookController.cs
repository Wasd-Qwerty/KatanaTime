using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CookController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectsPrefabs;
    public List<GameObject> objectsOnScene;

    private int kolvoEdible = 0;
    private int kolvoInedible = 0;
    
    [SerializeField] private Transform[] _objectSpawnPos;

    [SerializeField] private Animator _animator;

    private Rigidbody _rb;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private List<Vector3> _forceDirections;
    [SerializeField] private Vector3 _forceFridgeDirection;
    [SerializeField] private float _force;
    [SerializeField] private float _timeToDestroy = 4f;

    public LayerMask edibleLayer;
    public LayerMask inedibleLayer;
    
    private Transform pos;
    
    [SerializeField] private GameObject _fridge;
    [SerializeField] private GameObject _fridgePrefab;
    
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

        var randomIndexPos = Random.Range(0, _objectsPrefabs.Count);
        var fruitPrefab = _objectsPrefabs[randomIndexPos];

        if ((edibleLayer & (1 << fruitPrefab.gameObject.layer)) != 0)
        {
            kolvoEdible++;
            Debug.Log("Съедобно: " + kolvoEdible);
        }
        if ((inedibleLayer & (1 << fruitPrefab.gameObject.layer)) != 0)
        {
            kolvoInedible++;
            Debug.Log("Несъедобно: " + kolvoInedible);
        }
        
        // _objectsPrefabs.RemoveAt(0);
        
        var fruit = Instantiate(fruitPrefab, pos.position, Quaternion.identity);

        _rb = fruit.GetComponent<Rigidbody>();
        _rb.AddForce(_forceDirections[0] * _force, _forceMode);
        objectsOnScene.Add(fruit);
        Destroy(fruit, _timeToDestroy);
    }

    

    public void ThrowTheFridge()
    {
        var localPosition = _fridge.transform.position;
        var localRotation = _fridge.transform.rotation;
        var scale = _fridge.transform.lossyScale;
        
        Destroy(_fridge);

        var newFridge = Instantiate(_fridgePrefab, localPosition, localRotation);
        newFridge.transform.localScale = scale;

        var rb = newFridge.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(_forceFridgeDirection * _force, _forceMode);
    }
}