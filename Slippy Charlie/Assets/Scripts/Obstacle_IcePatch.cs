using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_IcePatch : MonoBehaviour
{

    PlayerController controller;
    bool addForce;
    public float slipForce = 1000;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            if(addForce)
            {
                Debug.Log("it's working");


                //controller.head.AddForce(controller.hips.transform.forward * slipForce * 1.5f);

                //controller.SetPlayerDeadState(true);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controller = other.gameObject.transform.root.GetComponent<PlayerController>();
            if(controller.isGrounded)
            {
                addForce = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controller = other.gameObject.GetComponent<PlayerController>();
            if (controller.isGrounded)
            {
                addForce = false;
            }
        }
    }

}
