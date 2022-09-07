using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int count;
    SkinCustom skin;
    public static bool isSave = false;
    public GameObject BtnContinue;

    
    void Awake()
    {
        skin = FindObjectOfType<SkinCustom>();
    }
    private void Update()
    {
        if (isSave == true)
        {
            BtnContinue.SetActive(true); 
        }
        else
        {
            BtnContinue.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Option()
    {
        SkinCustom.numberOfTexture += 1;
    }
    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
