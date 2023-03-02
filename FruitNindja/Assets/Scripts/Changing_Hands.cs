using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_Hands : MonoBehaviour
{
    [SerializeField] GameObject left_hand_knife;
    [SerializeField] GameObject left_hand_pan;
    [SerializeField] GameObject right_hand_knife;
    [SerializeField] GameObject right_hand_pan;

    [Header("Руки смерти")] 

    [SerializeField] private GameObject leftDiedHand;
    [SerializeField] private GameObject rightDiedHand;

    private void Update()
    {
        Changing();
    }

    void Changing()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Touch))
        {
            left_hand_knife.SetActive(false);
            right_hand_knife.SetActive(true);
            left_hand_pan.SetActive(true);
            right_hand_pan.SetActive(false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
        {
            left_hand_knife.SetActive(true);
            right_hand_knife.SetActive(false);
            left_hand_pan.SetActive(false);
            right_hand_pan.SetActive(true);
        }
    }

    public void Death()
    {
        left_hand_knife.SetActive(false);
        right_hand_knife.SetActive(false);
        left_hand_pan.SetActive(false);
        right_hand_pan.SetActive(false);
        leftDiedHand.SetActive(true);
        rightDiedHand.SetActive(true);
        Destroy(this);
    }
}