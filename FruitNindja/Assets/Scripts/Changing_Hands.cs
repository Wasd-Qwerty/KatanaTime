using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_Hands : MonoBehaviour
{
    [SerializeField] GameObject left_hand_knife;
    [SerializeField] GameObject left_hand_pan;
    [SerializeField] GameObject right_hand_knife;
    [SerializeField] GameObject right_hand_pan;

    bool isPressed;
    private void Update()
    {
        Changing();
        //if (OVRInput.Axis1D.PrimaryIndexTrigger) isPressed = true;
        //if (OVRInput.Axis1D.SecondaryIndexTrigger == 0) isPressed = false;
        ///if (OVRInput.GetUp(OVRInput.Button.One)) isPressed = true;
        //if (OVRInput.GetUp(OVRInput.Button.Two)) isPressed = false;
    }
    void Changing()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            left_hand_knife.SetActive(false);
            right_hand_knife.SetActive(true);
            left_hand_pan.SetActive(true);
            right_hand_pan.SetActive(false);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            left_hand_knife.SetActive(true);
            right_hand_knife.SetActive(false);
            left_hand_pan.SetActive(false);
            right_hand_pan.SetActive(true);
        }
    }
}
