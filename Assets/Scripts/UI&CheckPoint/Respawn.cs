using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform point;
    private SpawnModule gm;
  
    private void OnTriggerEnter(Collider other)
    {
        gm = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<SpawnModule>();
        if (other.gameObject.CompareTag("item"))
        {
            other.gameObject.transform.position = gm.lastCheckpointPos;
            Physics.SyncTransforms();
        }
    }
}
