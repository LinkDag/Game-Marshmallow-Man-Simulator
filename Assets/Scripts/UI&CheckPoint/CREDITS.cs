
using UnityEngine;
using UnityEngine.SceneManagement;

public class CREDITS : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain() {
        SceneManager.LoadScene("Menu");

    }
}
