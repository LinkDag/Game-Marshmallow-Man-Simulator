using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCustom : MonoBehaviour
{
    public Texture[] textures;

    public static int numberOfTexture;


    SkinnedMeshRenderer skin;
    // Start is called before the first frame update
    void Start()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfTexture == textures.Length)
        {
            numberOfTexture = 0;
        }
        skin.material.mainTexture = textures[numberOfTexture];

        
    }
}
