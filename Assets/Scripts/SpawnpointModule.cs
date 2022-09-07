using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointModule : MonoBehaviour
{
    private static SpawnpointModule instance;
    public Vector3 lastCheckpointPos;
    public GameObject player;
    public GameObject nameObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        /*else {
            Destroy(gameObject);
        }*/
    }
    private void Start()
    {
        player = (GameObject)Resources.Load(nameObject.name, typeof(GameObject));
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        GameObject.Instantiate(player, lastCheckpointPos, Quaternion.identity);

    }

}
