using UnityEngine;
using EzySlice;
public class SlicerMeshes : MonoBehaviour
{
    public LayerMask sliceMask;
    public bool isTouched;
    public Material materialAfterSlice;
    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                GameObject upperHullGameobject, lowerHullGameobject;
                Material sliceMaterial = null;
                if (objectToBeSliced.gameObject.GetComponent<SlicableMaterial>() != null)
                {
                    sliceMaterial = objectToBeSliced.gameObject.GetComponent<SlicableMaterial>().sliceMaterial;
                }
                if (sliceMaterial != null)
                {
                    SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, sliceMaterial);
                    upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, sliceMaterial);
                    lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, sliceMaterial);
                }
                else
                {
                    SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);
                    upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                    lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);
                }

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(objectToBeSliced.gameObject);
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
