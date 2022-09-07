using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public Animator anim;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item") || other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isButton", true);
           
            door.GetComponent<Animator>().SetBool("OpenDoor", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("item") || other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isButton", false);
           
            door.GetComponent<Animator>().SetBool("OpenDoor", false);
        }
    }
}
