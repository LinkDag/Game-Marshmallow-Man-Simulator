using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playing : MonoBehaviour
{
    public GameObject player;
    public GameObject PlayerClone;
    private SpawnModule gm;
    public bool isDie = false;
    private GameObject instantiatedObj;
    public bool IsPlaying = false;
    public bool IsInvulnerable = false;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<SpawnModule>();
        player = (GameObject)Resources.Load("MainPlayer", typeof(GameObject));
    }
    private void Update()
    {
        PlayerClone = GameObject.FindGameObjectWithTag("Player");
    }

    public void Win()
    {
        IsInvulnerable = true;
        
    }
    public void Die()
    {
        Movement move = GetComponent<Movement>();
        move.cap.enabled = !move.cap.enabled;
        move.hips.constraints = RigidbodyConstraints.None;
        isDie = true;
        Destroy(PlayerClone, 0f);
        GameObject.Instantiate(player, gm.lastCheckpointPos, Quaternion.identity);
    }
    private void OnTriggerExit(Collider other)
    {
        if (PlayerClone == null)
        {
            return;
        }
        else
        {
            if (other.gameObject.CompareTag("DeathFloor"))
            {
                Destroy(PlayerClone, 1f);
                GameObject.Instantiate(player, gm.lastCheckpointPos, Quaternion.identity);
            }
        }
    }
    
}
