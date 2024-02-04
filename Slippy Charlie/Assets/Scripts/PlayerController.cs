using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float speed = 150f;
    //public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public Rigidbody head;
    public Rigidbody torso;
    private ConfigurableJoint hipJoint;
    private JointDrive hipJointDrive;

    public bool isGrounded = true;
    public bool isMoving = false;
    public bool playerIsDead = false;

    private float AngDriveYZ_PositionSpring_StartingValue;
    public float AngDriveYZ_PositionSpring_CurrentValue;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        hipJoint = hips.gameObject.GetComponent<ConfigurableJoint>();
        AngDriveYZ_PositionSpring_StartingValue = hipJoint.angularYZDrive.positionSpring;
        AngDriveYZ_PositionSpring_CurrentValue = AngDriveYZ_PositionSpring_StartingValue;
        hipJointDrive = hipJoint.angularYZDrive;
        isGrounded = true;
        gameManager = FindObjectOfType<GameManager>();
        allowUpdate = true;
    }


    public float breakingDelta = 100f;
    public float recoveryDelta = 50f;

    public bool allowUpdate;
  
    // Update is called once per frame
    void Update()
    {
        if (allowUpdate)
        {
            hipJointDrive.positionDamper = hipJoint.angularYZDrive.positionDamper;
            hipJointDrive.maximumForce = hipJoint.angularYZDrive.maximumForce;
            hipJointDrive.useAcceleration = hipJoint.angularYZDrive.useAcceleration;

            if (!playerIsDead)
            {
                if (hipJoint != null)
                {

                    float localFwdVel = Mathf.Abs(Vector3.Dot(hips.gameObject.transform.forward, hips.velocity));
                    Debug.Log("fwd velocity is: " + localFwdVel);

                    //What we really want is to change the Angular Drive YZ Position Spring.
                    if (isMoving == true && (hips.rotation.x > .02f || hips.rotation.x < -.02f) || localFwdVel >.5f)
                    {
                        AngDriveYZ_PositionSpring_CurrentValue = MoveTowards(AngDriveYZ_PositionSpring_CurrentValue, 0, (breakingDelta*VelocityMultiplier(hips,0,5))* Time.deltaTime);
                        if (hipJoint.angularYZDrive.positionSpring <= 50f && !playerIsDead)
                        {                          
                            hipJoint.angularYZDrive = hipJointDrive;
                            if (gameManager != null)
                            {
                                gameManager.OnDeath();
                            }
                            SetPlayerDeadState(true);
                            hipJointDrive.positionDamper = hipJoint.angularYZDrive.positionDamper;
                            hipJointDrive.maximumForce = hipJoint.angularYZDrive.maximumForce;
                            hipJointDrive.useAcceleration = hipJoint.angularYZDrive.useAcceleration;
                            hipJointDrive.positionSpring = 0;
                            hipJoint.angularYZDrive = hipJointDrive;                          
                        }
                    }
                    else
                    {

                        AngDriveYZ_PositionSpring_CurrentValue = MoveTowards(AngDriveYZ_PositionSpring_CurrentValue, AngDriveYZ_PositionSpring_StartingValue, recoveryDelta * Time.deltaTime);
                    }

                    hipJointDrive.positionSpring = AngDriveYZ_PositionSpring_CurrentValue;
                    hipJoint.angularYZDrive = hipJointDrive;


                }
            }
        }
        else
        {
            AngDriveYZ_PositionSpring_CurrentValue = 0;
            hipJointDrive.positionSpring = 0;
            hipJoint.angularYZDrive = hipJointDrive;
        }
     
    }

    public void SetPlayerDeadState(bool isDead = false)
    {
        playerIsDead = isDead;
        allowUpdate = false;
    }

    public float MoveTowards(float current, float target, float maxDelta)
    {
        if (Mathf.Abs(target - current) <= maxDelta)
        {
            return target;
        }
        return current + Mathf.Sign(target - current) * maxDelta;
    }

    public float VelocityMultiplier(Rigidbody rb, float minValue, float maxValue)
    {
        Vector3 rbForward = rb.gameObject.transform.forward;
        float localFwdVel = Mathf.Abs(Vector3.Dot(rbForward, rb.velocity));

        float normalizedVelocity = Mathf.Clamp(localFwdVel, minValue, maxValue)/maxValue;

        //Debug.Log("normalized velocity is: " + normalizedVelocity);
    

        return normalizedVelocity;

    }


    public IEnumerator Reset(float delay = 0)
    {
        Debug.Log("reset called");
        yield return new WaitForSeconds(delay);
        SetPlayerDeadState(false);
        AngDriveYZ_PositionSpring_CurrentValue = AngDriveYZ_PositionSpring_StartingValue;
        hipJointDrive.positionSpring = AngDriveYZ_PositionSpring_CurrentValue;
        hipJoint.angularYZDrive = hipJointDrive;
        AngDriveYZ_PositionSpring_CurrentValue = AngDriveYZ_PositionSpring_StartingValue;
        allowUpdate = true; 
        yield return null;
    }

    private void FixedUpdate()
    {
        if (!playerIsDead)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetAxis("Jump") > 0)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    if(hips != null)
                    {
                        hips.AddForce(hips.transform.forward * speed * 1.5f);
                    }
                    if(torso != null)
                    {
                        torso.AddForce(torso.transform.forward * speed * 1f);
                    }
                   
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (hips != null)
                    {
                        hips.AddForce(-hips.transform.forward * speed * 1.5f);
                    }
                    if (torso != null)
                    {
                        torso.AddForce(-torso.transform.forward * speed * 1f);
                    }
                }
                if (Input.GetAxis("Jump") > 0)
                {
                    if(isGrounded)
                    {
                        hips.AddForce(new Vector3(0, jumpForce, 0));
                        isGrounded = false;
                    }
                }
                    isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

    }
}
