using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody hips;
    ConfigurableJoint joint;
    public CapsuleCollider cap;
    public Transform cam;

    public float speed;
    public float strafespeed;
    public float jumpForce;
    public float Turnsmoothtime = 0.1f;
    float turnSmoothVelocity;

    public bool isGrounded = false;
    public bool isInAir;
    public int InAirHeight;
    public bool CanMove;


    // Start is called before the first frame update
    void Start()
    {
        hips = GetComponent<Rigidbody>();
        joint = GetComponent<ConfigurableJoint>();
        cap = GetComponent<CapsuleCollider>();
        isInAir = true;
    }

    // Update is called once per frame
    public bool IsMoving()
    {
        return hips.velocity.magnitude > 0.1f;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 drirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (drirection.magnitude >= 0.1)
        {
            float targetAngle = cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, Turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        if (CanMove == true)
        {
            PlayerMoverment();
        }
    }
    private void PlayerMoverment()
    {
        if (Input.GetKey(KeyCode.W))
        {
            hips.AddForce(hips.transform.forward * speed);
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkLeft", true);
            hips.AddForce(-hips.transform.right * strafespeed);
        }
        else
        {
            anim.SetBool("isWalkLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalk", true);
            hips.AddForce(-hips.transform.forward * speed * 1.5f);
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalk", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkRight", true);
            hips.AddForce(hips.transform.right * strafespeed);
        }
        else
        {
            anim.SetBool("isWalkRight", false);
        }
        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded != true)
            {
                return;
            }
            else
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
            CanMove = true;
            if (isInAir == true)
            {
                StartCoroutine(CapOff());
            }
            PhysicMaterial newMat2 = Resources.Load("slide2", typeof(PhysicMaterial)) as PhysicMaterial;
            cap.material = newMat2;
        }
        if (collision.gameObject.CompareTag("slide"))
        {
            PhysicMaterial newMat = Resources.Load("slide0", typeof(PhysicMaterial)) as PhysicMaterial;
            cap.material = newMat;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
             
            checkTimeInAir();
            CanMove = false;
        }
        
    }
    private void checkTimeInAir()
    {
        if (!Physics.Raycast(transform.position, -transform.up, InAirHeight))
        {
            isInAir = true;
        }
    }
    IEnumerator CapOff()
    {
        CanMove = false;
        cap.enabled = !cap.enabled;
        hips.constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(5f);
        cap.enabled = !cap.enabled;
        yield return new WaitForSeconds(2f);
        hips.constraints = RigidbodyConstraints.FreezeRotation;
        CanMove = true;
    }

}
