using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inedible_HP_Impact : MonoBehaviour
{
    bool isHited = false;
    
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && isHited == false) GameObject.Find("Player").GetComponent<HealthBar>().Damage();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "LeftHandPan" || collision.gameObject.name == "RightHandPan") isHited = true;
        if (collision.gameObject.name == "LeftHandKnife" || collision.gameObject.name == "RightHandPan") GetComponent<HealthBar>().Damage();
    }
}
