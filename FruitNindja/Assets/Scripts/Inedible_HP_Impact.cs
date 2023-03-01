using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inedible_HP_Impact : MonoBehaviour
{
    bool isHited = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OVRCameraRig" && isHited == false)
        {
            GameObject.Find("OVRCameraRig").GetComponent<HealthBar>().Damage();
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LeftHandPan" || collision.gameObject.name == "RightHandPan")
        {
            isHited = true;
            Destroy(this);
        }

        if (collision.gameObject.name == "right_hand_with_knife" || collision.gameObject.name == "left_hand_with_knife")
        {
            GameObject.Find("OVRCameraRig").GetComponent<HealthBar>().Damage();
            Destroy(this);
        }
    }
}
