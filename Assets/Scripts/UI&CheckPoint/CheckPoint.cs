using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpawnModule SpawnModule;

    private void Start()
    {
        SpawnModule = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<SpawnModule>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnModule.lastCheckpointPos = transform.position;
        }
    }
}
