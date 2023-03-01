using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Physics : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Quaternion rotationY = Quaternion.AngleAxis(-8, new Vector3(1, 1, 0));
        transform.rotation *= rotationY;
    }
}
