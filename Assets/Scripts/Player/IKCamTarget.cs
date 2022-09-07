
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKCamTarget : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
        MainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
}
