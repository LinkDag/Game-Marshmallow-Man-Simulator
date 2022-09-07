using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditLoad : MonoBehaviour
{
    public Camera MainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MainCamera = Camera.main;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
