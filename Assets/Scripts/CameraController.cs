using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float rotationspeed = 1;
    public Transform root;

    float MouseX, MouseY;

    public float stomachOffset;

    public ConfigurableJoint hipJoint, stomachJoint;

    private RaycastHit hit;
    private Vector3 cameraOffset;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        cameraOffset = root.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /* if (Physics.Linecast(root.position, root.position + cameraOffset, out hit))
        {
            root.position = new Vector3(0, 0, -Vector3.Distance(root.position, hit.point));
        }
        else
        {
            root.position = cameraOffset;
        }*/
        ComeraControl();
        
       
    }
    void ComeraControl()
    {
        MouseX += Input.GetAxis("Mouse X") * rotationspeed;
        MouseY -= Input.GetAxis("Mouse Y") * rotationspeed;
        MouseY = Mathf.Clamp(MouseY, -35, 60);
        Quaternion rootRotation = Quaternion.Euler(MouseY, MouseX, 0);
        root.rotation = rootRotation;
        hipJoint.targetRotation = Quaternion.Euler(0, -MouseX, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-MouseY + stomachOffset, 0, 0);
    }
}
