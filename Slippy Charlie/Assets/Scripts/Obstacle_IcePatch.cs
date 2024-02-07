using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_IcePatch : MonoBehaviour
{

    PlayerController controller;
    bool playerIsOnIce = false;
    bool hasSwitched = false;
    public float slipForce = 1000;
    public PhysicMaterial physMaterial_Ice;
    public PhysicMaterial physMaterial_CharlieLegs;


    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            if(playerIsOnIce && controller.isGrounded)
            {
                Debug.Log("it's working");
                if(!hasSwitched)
                {
                    if (physMaterial_Ice != null)
                    {
                        Collider[] colliders = controller.GetComponentsInChildren<Collider>();
                        foreach (Collider collider in colliders)
                        {
                            collider.material = physMaterial_Ice;
                        }
                        hasSwitched = true;
                    }
                }
               
            }
            else
            {
                if(!hasSwitched)
                {
                    if (physMaterial_CharlieLegs != null)
                    {
                        Collider[] colliders = controller.GetComponentsInChildren<Collider>();
                        foreach (Collider collider in colliders)
                        {
                            collider.material = physMaterial_CharlieLegs;
                        }
                        Debug.Log("change charlie");
                        hasSwitched = true;
                    }
                }
                
            }

        }
      
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {        
            controller = other.gameObject.transform.root.GetComponent<PlayerController>();
            hasSwitched = false;
            playerIsOnIce = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controller = other.gameObject.transform.root.GetComponent<PlayerController>();
            playerIsOnIce = false;
            hasSwitched = false;
        }
    }

}
