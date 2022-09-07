using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public void LoadMenu () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
