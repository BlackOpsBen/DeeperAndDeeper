using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSkybox : MonoBehaviour
{
    /*public Color topColor1;
    public Color bottomColor1;
    public float gradientHeight = 1f;*/

    private CalculateDistance calculateDistance;

    [SerializeField] private SkyThreshold[] skyboxThresholds;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        calculateDistance = FindObjectOfType<CalculateDistance>();

        Material skyboxMatCopy = new Material(RenderSettings.skybox);

        RenderSettings.skybox = skyboxMatCopy;

        RenderSettings.skybox.SetColor("_colorTop", skyboxThresholds[0].topColor);
        RenderSettings.skybox.SetColor("_colorBottom", skyboxThresholds[0].bottomColor);
        RenderSettings.skybox.SetFloat("_gradientHeight", skyboxThresholds[0].height);
    }

    // Update is called once per frame
    void Update()
    {
        /*RenderSettings.skybox.SetColor("_colorTop", topColor1);
        RenderSettings.skybox.SetColor("_colorBottom", bottomColor1);
        RenderSettings.skybox.SetFloat("_gradientHeight", gradientHeight);*/
        CheckCurrentThreshold();

        LerpColor();
    }

    private void LerpColor()
    {
        /*Color currentTop = RenderSettings.skybox.GetColor("_colorTop");
        Color currentBottom = RenderSettings.skybox.GetColor("_colorBottom");
        float currentHeight = RenderSettings.skybox.GetFloat("_gradientHeight");*/
        Color currentTop = skyboxThresholds[Math.Max(currentIndex - 1, 0)].topColor;
        Color currentBottom = skyboxThresholds[Math.Max(currentIndex - 1, 0)].bottomColor;
        float currentHeight = skyboxThresholds[Math.Max(currentIndex - 1, 0)].height;

        Color targetTop = skyboxThresholds[currentIndex].topColor;
        Color targetBottom = skyboxThresholds[currentIndex].bottomColor;
        float targetHeight = skyboxThresholds[currentIndex].height;

        float segmentProgress = (calculateDistance.GetDistance() - skyboxThresholds[Math.Max(currentIndex - 1, 0)].threshold) / (skyboxThresholds[currentIndex].threshold - skyboxThresholds[Math.Max(currentIndex - 1, 0)].threshold);
        Color lerpTop = Color.Lerp(currentTop, targetTop, segmentProgress);
        Color lerpBottom = Color.Lerp(currentBottom, targetBottom, segmentProgress);
        float lerpHeight = Mathf.Lerp(currentHeight, targetHeight, segmentProgress);

        RenderSettings.skybox.SetColor("_colorTop", lerpTop);
        RenderSettings.skybox.SetColor("_colorBottom", lerpBottom);
        RenderSettings.skybox.SetFloat("_gradientHeight", lerpHeight);
    }

    private void CheckCurrentThreshold()
    {
        if (calculateDistance.GetDistance() > skyboxThresholds[currentIndex].threshold)
        {
            if (currentIndex < skyboxThresholds.Length - 1)
            {
                currentIndex++;
            }
        }
    }
}

[System.Serializable]
public class SkyThreshold
{
    public float threshold;
    public Color topColor;
    public Color bottomColor;
    public float height = 1;
}
