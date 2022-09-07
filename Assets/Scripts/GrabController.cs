using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Animator animator;
    GameObject grabObj;

    public Rigidbody rb;
    public FixedJoint fjL,fjR;

    public int isLeftorRight;
    public bool alreadyGrabbing=false;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(isLeftorRight))
        {
            alreadyGrabbing = true;
            if (isLeftorRight == 0)
            {
                /*animator.SetBool( "isHandLUp", true);*/

                
            }
            else if (isLeftorRight == 1)
            {
                animator.SetBool("isHandRUp", true);
            }

        }else if (Input.GetMouseButtonUp(isLeftorRight))
        {
            alreadyGrabbing = false;
            if (isLeftorRight == 0)
            {
                animator.SetBool("isHandLUp", false);
                if (grabObj != null) {
                    Destroy(fjL);
                }
            }else if(isLeftorRight == 1)
            {
                animator.SetBool("isHandRUp", false);
                if (grabObj != null )
                {
                    Destroy(fjR);
                }
            }
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        
        grabObj = collision.gameObject;
        Debug.Log("Phat hien va cham vơi" + collision.gameObject.name);
        if (alreadyGrabbing == true)
        {
            if (isLeftorRight == 0)
            {
                fjL = grabObj.AddComponent<FixedJoint>();
                fjL.connectedBody = rb;
                fjL.breakForce = 9001;
                Debug.Log("tao joint voi" + collision.gameObject.name);
            }
            else if (isLeftorRight == 1) {
                fjR = grabObj.AddComponent<FixedJoint>();
                fjR.connectedBody = rb;
                fjR.breakForce = 9001;
                Debug.Log("tao joint voi" + collision.gameObject.name);

            }
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        alreadyGrabbing = false;
        Debug.Log("Phat hien  hêt cham vơi" + collision.gameObject.name);
    }
}
