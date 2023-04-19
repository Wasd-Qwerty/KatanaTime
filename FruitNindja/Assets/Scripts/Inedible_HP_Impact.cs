using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inedible_HP_Impact : MonoBehaviour
{
    private BattingObject _batting;

    private void Start()
    {
        _batting = GetComponent<BattingObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_batting._isBatting)
        {
            return;
        }
        if (collision.gameObject.name == "LeftHandPan" || collision.gameObject.name == "RightHandPan")
        {
            Destroy(this);
        }
        
        if (collision.gameObject.name == "right_hand_with_knife" || collision.gameObject.name == "left_hand_with_knife" || collision.gameObject.name == "right_hand_with_cleaver" || collision.gameObject.name == "left_hand_with_cleaver" )
        {
            GameObject.Find("OVRCameraRig").GetComponent<HealthBar>().Damage();
            gameObject.layer = 0;
            Destroy(GetComponent<Collider>());
            Destroy(this);
        }
    }
}
