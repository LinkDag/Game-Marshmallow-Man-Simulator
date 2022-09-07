using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbColision : MonoBehaviour
{
    Movement movement;
    Playing playing;
    public ConfigurableJoint cj;
    public bool EnableClimb;
    JointDrive jointDriveX, jointDriveYZ, jdZero;


    // Start is called before the first frame update
    void Start()
    {

        movement = GameObject.FindObjectOfType<Movement>().GetComponent<Movement>();
        playing = GameObject.FindObjectOfType<Playing>().GetComponent<Playing>();
        cj = GetComponent<ConfigurableJoint>();
        jointDriveX = cj.angularXDrive;
        jointDriveYZ = cj.angularYZDrive;
        OnAir();
    }
    private void Update()
    {
        SetupString();
    }
    private void SetupString()
    {
        if (playing.isDie == true)
        {
            OnAir();
        }
        else
        {
            if (movement.isInAir)
            {
                if (movement.isGrounded)
                {
                    StartCoroutine(Coroutine());
                }
                else
                {
                    OnAir();
                }
            }
            else
            {
                if (movement.isGrounded)
                {
                    OnGround();
                }
                else
                {
                    if (EnableClimb)
                    {
                        OnAir();
                    }
                }
            }
        }
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(5f);
        OnGround();
        movement.isInAir=false;
    }
    public void OnAir()
    {
        jdZero.positionSpring = 0f;
        cj.angularXDrive = jdZero;
        cj.angularYZDrive = jdZero;
    }
    private void OnGround()
    {
        cj.angularXDrive = jointDriveX;
        cj.angularYZDrive = jointDriveYZ;
    }
}   
