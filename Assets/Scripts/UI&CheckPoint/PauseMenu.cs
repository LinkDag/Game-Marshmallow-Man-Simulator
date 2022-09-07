using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public Camera MainCamera;
    SpawnModule gm;
    
    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<SpawnModule>();
        Resume();
      
    }
    // Update is called once per frame
    void Update()
    {
        MainCamera = Camera.main;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;

    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void LoadMenu()
    {
        
        Menu.isSave = true;
        SpawnModule.savePoint = gm.lastCheckpointPos;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void LoadLastCP()
    {
        Playing player = FindObjectOfType<Playing>();
        player.Die();
        Resume();
    }
    
}
