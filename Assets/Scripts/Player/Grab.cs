using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Grab : MonoBehaviour
{
    public Rig layerL, layerR;
    public GameObject grabObj;

    public Rigidbody rb;
    public FixedJoint fjL, fjR;

    public int isLeftorRight;
    public bool alreadyGrabbing = false;
    public float TargetWeightL, TargetWeightR;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        layerL.weight = Mathf.Lerp(layerL.weight, TargetWeightL, 3f * Time.deltaTime);
        layerR.weight = Mathf.Lerp(layerR.weight, TargetWeightR, 3f * Time.deltaTime);
        if (Input.GetMouseButtonDown(isLeftorRight))
        {
            alreadyGrabbing = true;
            if (isLeftorRight == 0)
            {
                TargetWeightL = 1f;
            }
            else if (isLeftorRight == 1)
            {
                TargetWeightR = 1f;
            }
        }
        else if (Input.GetMouseButtonUp(isLeftorRight))
        {
            alreadyGrabbing = false;
            if (isLeftorRight == 0)
            {
                TargetWeightL = 0f;
                if (grabObj != null)
                {
                    Destroy(fjL);
                }
                else
                {
                    return;
                }
            }
            else if (isLeftorRight == 1)
            {
                TargetWeightR = 0f;
                if (grabObj != null)
                {
                    Destroy(fjR);
                }
                else
                {
                    return;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        alreadyGrabbing = false;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        grabObj = collision.gameObject;
        if (alreadyGrabbing == true)
        {
            if (isLeftorRight == 0)
            {
                fjL = grabObj.AddComponent<FixedJoint>();
                fjL.connectedBody = rb;
            }
            else if (isLeftorRight == 1)
            {
                fjR = grabObj.AddComponent<FixedJoint>();
                fjR.connectedBody = rb;
            }
            alreadyGrabbing = false;
        }
    }
}
