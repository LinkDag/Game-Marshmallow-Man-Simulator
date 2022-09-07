using UnityEngine;

public class StartGame1 : MonoBehaviour
{
    /*    private Playing Play;
    */
    Playing player;

    public void Update()
    {
        player = FindObjectOfType<Playing>();

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            /* Play.IsPlaying = true;*/
            player.IsPlaying = true;
        }
    }
}
