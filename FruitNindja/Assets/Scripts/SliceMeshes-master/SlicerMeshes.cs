using System;
using UnityEngine;
using EzySlice;

public class SlicerMeshes : MonoBehaviour
{
    public LayerMask sliceMask;
    GameObject upperHullGameobject, lowerHullGameobject;

    [SerializeField] private ScoreManager _scoreManager;
    
    [SerializeField] private float _timeToDestroy;
    public Material materialAfterSlice;

    public void Touch()
    {
        Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
        foreach (Collider objectToBeSliced in objectsToBeSliced)
        {
            try
            {
                var parrentVelocity = objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity;
            
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
                upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);
              
                upperHullGameobject.GetComponent<Rigidbody>().velocity = parrentVelocity;
                lowerHullGameobject.GetComponent<Rigidbody>().velocity = parrentVelocity;

                Destroy(upperHullGameobject, _timeToDestroy);
                Destroy(lowerHullGameobject, _timeToDestroy);
            
                Destroy(objectToBeSliced.gameObject);
            
                _scoreManager.IncreaseScore(100);
            }
            catch (Exception e)
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
