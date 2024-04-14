using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherChange : MonoBehaviour
{
    public Material skyboxMaterial;

    void Update()
    {
        RenderSettings.skybox = skyboxMaterial;
        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }
}