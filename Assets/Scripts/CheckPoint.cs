using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpawnpointModule gm;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Sp").GetComponent<SpawnpointModule>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            gm.lastCheckpointPos = transform.position;
        }
    }
}
