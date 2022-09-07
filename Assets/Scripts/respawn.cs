using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform point;
    private SpawnpointModule gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Sp").GetComponent<SpawnpointModule>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.position= gm.lastCheckpointPos;
            
            Physics.SyncTransforms();
        }
    }
}
