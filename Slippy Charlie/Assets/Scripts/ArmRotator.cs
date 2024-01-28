using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    private ConfigurableJoint cj;
    public Quaternion startingRotation;
    public float currentRotateSpeed;
    public float walkRotateSpeed = 400;
    public float JumpRotateSpeed = 800;
    public float pingPongAngleAmount = 180;
    public bool isLeftLimb = false;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        cj = this.gameObject.GetComponent<ConfigurableJoint>();
        cj.targetRotation = startingRotation;
        playerController = GameObject.FindObjectOfType<PlayerController>();
        currentRotateSpeed = walkRotateSpeed;
    }

    float t = 0f;
  
    // Update is called once per frame
    void Update()
    {
        if(playerController!= null)
        {
            if (!playerController.playerIsDead)
            {
                if (playerController.isMoving)
                {
                    if (!playerController.isGrounded)
                    {
                        currentRotateSpeed = JumpRotateSpeed;
                    }
                    else
                    {
                        currentRotateSpeed = walkRotateSpeed;
                    }

                    t = Mathf.PingPong(Time.time * currentRotateSpeed, pingPongAngleAmount);

                    if (isLeftLimb)
                    {
                        cj.targetRotation = GetRotationTarget();
                    }
                    else
                    {
                        cj.targetRotation = Quaternion.Inverse(GetRotationTarget());
                    }

                }
                else
                {
                    cj.targetRotation = Quaternion.identity;
                }
            }
            else
            {
                cj.targetRotation = Quaternion.identity;
            }
        }
        
      
    }

    public virtual Quaternion GetRotationTarget()
    {
        Quaternion rotationTarget;

       
        rotationTarget = Quaternion.Euler(startingRotation.x, Mathf.PingPong(Time.time * currentRotateSpeed, pingPongAngleAmount * 2) - pingPongAngleAmount, startingRotation.z);
        
       
        return rotationTarget;
    }

}
