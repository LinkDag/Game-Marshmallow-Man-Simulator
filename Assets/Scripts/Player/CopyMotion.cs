using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    public bool mirror;
    public ConfigurableJoint cj;
    Quaternion tg;
    // Start is called before the first frame update
    void Start()
    {
        this.cj = this.GetComponent<ConfigurableJoint>();
        this.tg = this.targetLimb.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mirror)
        {

            cj.targetRotation = Quaternion.Inverse(this.targetLimb.localRotation);

        }
        else
        {
            cj.targetRotation = Quaternion.Inverse(this.targetLimb.localRotation) * tg;

        }
    }
}
