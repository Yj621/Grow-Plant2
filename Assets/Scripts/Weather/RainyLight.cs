using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainyLight : MonoBehaviour
{
    public GameObject rainyLight;
    public GameObject rainEffect;

    public void ActivateRainEffect() //비 오는 날의 조명 활성화
    {
        rainEffect.SetActive(true);
    }

    public void DeactivateRainEffect()//비 오는 날의 조명 비활성화
    {
        rainEffect?.SetActive(false);
    }

    public void ActivateCloudyLight()
    {
        rainyLight.SetActive(true);
    }
    public void DeactivateCloudyLight()
    {
        rainyLight.SetActive(false);
    }
}
