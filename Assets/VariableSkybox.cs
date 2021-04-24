using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSkybox : MonoBehaviour
{
    public Color topColor1;
    public Color bottomColor1;
    public float gradientHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetColor("_colorTop", topColor1);
        RenderSettings.skybox.SetColor("_colorBottom", bottomColor1);
        RenderSettings.skybox.SetFloat("_gradientHeight", gradientHeight);
    }
}
