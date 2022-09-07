using UnityEngine;
public class elevator : MonoBehaviour
{
    /*public int max;
    public int min;
    public int timeToMove;*/


    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {

        if (other.name== "Hips")
        {
            
            other.transform.parent.parent.parent = transform;
            
        }

    }
    void OnTriggerExit(Collider other)
    {

        if (other.name == "Hips")
        {
            other.transform.parent.parent.parent = null;
        }

    }

}
