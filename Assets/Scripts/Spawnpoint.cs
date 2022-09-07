using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public GameObject SP;
    public GameObject player;
    private Vector3 respawnLocation;
    public GameObject nameObject;
    
    // Start is called before the first frame update

    void Start()
    {
        player =(GameObject)Resources.Load(nameObject.name, typeof(GameObject));
        SP = GameObject.FindGameObjectWithTag("spawnpoint");
        respawnLocation = player.transform.position;
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnPlayer()
    {
        GameObject.Instantiate(player, SP.transform.position, Quaternion.identity);

    }


}
