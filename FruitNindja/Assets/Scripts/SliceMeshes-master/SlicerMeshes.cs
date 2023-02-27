using System;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;

public class SlicerMeshes : MonoBehaviour
{
    public LayerMask sliceMask;
    GameObject upperHullGameobject, lowerHullGameobject;

    
    // public bool isTouched;
    public Material materialAfterSlice;
    // private void Update()
    // {
    //     if (isTouched == true)
    //     {
    //         isTouched = false;
    //
    //         Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
    //         
    //         foreach (Collider objectToBeSliced in objectsToBeSliced)
    //         {
    //             GameObject upperHullGameobject, lowerHullGameobject;
    //             Material sliceMaterial = null;
    //             if (objectToBeSliced.gameObject.GetComponent<SlicableMaterial>() != null)
    //             {
    //                 sliceMaterial = objectToBeSliced.gameObject.GetComponent<SlicableMaterial>().sliceMaterial;
    //             }
    //             if (sliceMaterial != null)
    //             {
    //                 SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
    //                 upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
    //                 lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);
    //             }
    //             else
    //             {
    //                 SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
    //                 upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
    //                 lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);
    //             }
    //
    //             upperHullGameobject.transform.position = objectToBeSliced.transform.position;
    //             lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
    //
    //             MakeItPhysical(upperHullGameobject);
    //             MakeItPhysical(lowerHullGameobject);
    //             
    //             Destroy(upperHullGameobject, 3f);
    //             Destroy(lowerHullGameobject, 3f);
    //             Destroy(objectToBeSliced.gameObject);
    //         }
    //     }
    // }


    public void Touch()
    {
        Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
        foreach (Collider objectToBeSliced in objectsToBeSliced)
        {
           
            // Material sliceMaterial = null ;
            SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
            upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
            lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

            upperHullGameobject.transform.position = objectToBeSliced.transform.position;
            lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

            MakeItPhysical(upperHullGameobject);
            MakeItPhysical(lowerHullGameobject);
                
            Destroy(upperHullGameobject, 3f);
            Destroy(lowerHullGameobject, 3f);
            
            Destroy(objectToBeSliced.gameObject);
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
