using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Changing_Hands : MonoBehaviour
{
    [SerializeField] GameObject left_hand_knife;
    [SerializeField] GameObject left_hand_pan;
    [SerializeField] GameObject right_hand_knife;
    [SerializeField] GameObject right_hand_pan;

    public bool canChange = true;
    
    [Header("Руки смерти")] 

    [SerializeField] private GameObject leftDiedHand;
    [SerializeField] private GameObject rightDiedHand;

    private void Update()
    {
        Changing();
    }

    void Changing()
    {
        if (canChange)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                left_hand_knife.SetActive(false);
                right_hand_knife.SetActive(true);
                left_hand_pan.SetActive(true);
                right_hand_pan.SetActive(false);
            }

            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                left_hand_knife.SetActive(true);
                right_hand_knife.SetActive(false);
                left_hand_pan.SetActive(false);
                right_hand_pan.SetActive(true);
            }
        }
    }

    public void Death()
    {
        if (!canChange)
        {
            right_hand_knife.SetActive(true);
            left_hand_pan.SetActive(true);
            leftDiedHand.SetActive(false);
            rightDiedHand.SetActive(false);
            canChange = true;
            return;
        }
        left_hand_knife.SetActive(false);
        right_hand_knife.SetActive(false);
        left_hand_pan.SetActive(false);
        right_hand_pan.SetActive(false);
        leftDiedHand.SetActive(true);
        rightDiedHand.SetActive(true);
        canChange = false;
    }
}