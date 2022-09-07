using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float strafespeed;
    public float jumpForce;

    public Animator anim;
    public Rigidbody hips;

    ConfigurableJoint joint;

    private SpawnpointModule gm;

    public bool isGrounded=false ;
    // Start is called before the first frame update
    void Start()
    {
        hips = GetComponent<Rigidbody>();
        joint = GetComponent<ConfigurableJoint>();
        

        /*gm = GameObject.FindGameObjectWithTag("Sp").GetComponent<SpawnpointModule>();*/
        transform.position = gm.lastCheckpointPos;

    }
    // Update is called once per frame
   
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
             hips.AddForce(hips.transform.forward * speed );
             anim.SetBool("isWalk",true);
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
            hips.AddForce(-hips.transform.forward * speed);
        }
        else if(!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalk", false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkRight", true);
            hips.AddForce(hips.transform.right *strafespeed);
        }
        else 
        {
            anim.SetBool("isWalkRight", false);
        }


        if (Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                float jumpForce2 = jumpForce;
                jumpForce2 = Mathf.Clamp(jumpForce2, jumpForce, jumpForce + 1);
                hips.AddForce(new Vector3(0, jumpForce2, 0));
                isGrounded = false;
                
            }
        }
        
            
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Item"))
        {
            anim.SetBool("isJump", false);
        }
        if (other.gameObject.CompareTag("DeathFloor")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Item"))
        {
            anim.SetBool("isJump", true);
        }

    }
}
