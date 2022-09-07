using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerControler playerControler;
    ConfigurableJoint cj;

    // Start is called before the first frame update
    private void Start()
    {
        playerControler = GameObject.FindObjectOfType<PlayerControler>().GetComponent<PlayerControler>();
        cj = GetComponent<ConfigurableJoint>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ( !collision.gameObject.CompareTag("Item") ) {
            playerControler.isGrounded = true;
            
        }
        /*cj.angularXDrive = new JointDrive()
        {
            maximumForce = 0,
            positionDamper = 0,
            positionSpring = 500
        };
        cj.angularYZDrive = new JointDrive()
        {
            maximumForce = 0,
            positionDamper = 0,
            positionSpring = 500
        };*/

    }
    private void OnCollisionExit(Collision collision)
    {
        /*cj.angularXDrive = new JointDrive()
        {
            maximumForce = 0,
            positionDamper = 0,
            positionSpring = 500
        };
        cj.angularYZDrive = new JointDrive()
        {
            maximumForce = 0,
            positionDamper = 0,
            positionSpring = 500
        };*/
    }

}
//!collision.gameObject.CompareTag("Item") || 