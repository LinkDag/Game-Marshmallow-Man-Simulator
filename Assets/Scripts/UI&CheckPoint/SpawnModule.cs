using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModule : MonoBehaviour
{
    private static SpawnModule instance;
    public Vector3 lastCheckpointPos;
    public static GameObject player;
    public static Vector3 savePoint;
    public GameObject NamePlayer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;   
        }
        if (Menu.isSave)
        {
            lastCheckpointPos = savePoint;
            Menu.isSave = false;
        }
        else
        {
            return;
        }
    }
    
    private void Start()
    {
        player = (GameObject)Resources.Load(NamePlayer.name, typeof(GameObject));
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        GameObject.Instantiate(player, lastCheckpointPos, Quaternion.identity);
    }
}
