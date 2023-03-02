using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Physics : MonoBehaviour
{
    Quaternion originRotation;
    [SerializeField] float angleX;    
    [SerializeField] float angleY;    
    [SerializeField] float angleZ;

    void Update()
    {        
        Quaternion rotationX = Quaternion.AngleAxis(angleX, new Vector3(1, 0, 0));
        Quaternion rotationY = Quaternion.AngleAxis(angleY, new Vector3(0, 1, 0));
        Quaternion rotationZ = Quaternion.AngleAxis(angleZ, new Vector3(0, 0, 1));
        transform.rotation *= rotationX * rotationY * rotationZ;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
