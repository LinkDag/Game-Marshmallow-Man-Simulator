using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wincheck : MonoBehaviour
{
    
    public bool OnCanvas ;
    public GameObject UI;

    
    private void OnTriggerEnter(Collider other)
    {
        
        Playing character = other.GetComponent<Playing>();
        if (character != null)
        {
            character.IsPlaying = false;
            character.Win();
        }
        if (other.CompareTag("Player") && OnCanvas == true)
        {
            StartCoroutine(UseCanvas());
            OnCanvas = false;
        }
    }
    IEnumerator UseCanvas()
    {
        UI.SetActive(true);
        yield return new WaitForSeconds(5f);
        UI.SetActive(false);

    }

}
