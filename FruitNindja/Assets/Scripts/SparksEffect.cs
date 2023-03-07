using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksEffect : MonoBehaviour
{
    public ParticleSystem sparks;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 position = contact.point;
        Vector3 normal = contact.normal;
        Quaternion rotation = Quaternion.LookRotation(normal);
        sparks.transform.position = position;
        sparks.transform.rotation = rotation;
        
        sparks.Emit(10);
    }
}