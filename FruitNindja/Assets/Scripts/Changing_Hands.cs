using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_Hands : MonoBehaviour
{
    [SerializeField] GameObject left_hand_knife;
    [SerializeField] GameObject left_hand_pan;
    [SerializeField] GameObject right_hand_knife;
    [SerializeField] GameObject right_hand_pan;
    private void Update()
    {
        Changing();
    }
    void Changing()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            left_hand_knife.SetActive(false);
            right_hand_knife.SetActive(true);
            left_hand_pan.SetActive(true);
            right_hand_pan.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            left_hand_knife.SetActive(true);
            right_hand_knife.SetActive(false);
            left_hand_pan.SetActive(false);
            right_hand_pan.SetActive(true);
        }
    }
}
