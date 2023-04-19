using System;
using UnityEngine;
using EzySlice;
using UnityEditor;

public class SlicerMeshes : MonoBehaviour
{
    public LayerMask sliceMask;
    GameObject _upperHull, _lowerHull;

    [SerializeField] private ScoreManager _scoreManager;
    
    [SerializeField] private float _timeToDestroy;
    public Material materialAfterSlice;

    [SerializeField] private int _editNumberForIncrease = 100;
    public void Touch()
    {
        Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
        foreach (Collider objectToBeSliced in objectsToBeSliced)
        {
            try
            {
                objectToBeSliced.GetComponent<BattingObject>()._isSliced = true;
                var parrentVelocity = objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity;
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
                _upperHull = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                _lowerHull = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                _upperHull.transform.position = objectToBeSliced.transform.position;
                _lowerHull.transform.position = objectToBeSliced.transform.position;
                Destroy(objectToBeSliced.gameObject);

                MakeItPhysical(_upperHull);
                MakeItPhysical(_lowerHull);
              
                _upperHull.GetComponent<Rigidbody>().velocity = parrentVelocity;
                _lowerHull.GetComponent<Rigidbody>().velocity = parrentVelocity;
                

                Destroy(_upperHull, _timeToDestroy);
                Destroy(_lowerHull, _timeToDestroy);
                AudioManager.Instance.PlaySFX("Slice");
                _scoreManager.IncreaseScore(_editNumberForIncrease);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }
}
