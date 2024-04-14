using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunnyLight : MonoBehaviour
{
    public GameObject sunnyLight;

    public void ActivateSunnyLight() //맑은 날의 조명 활성화
    {
        sunnyLight.SetActive(true);
    }

    public void DeactivateSunnyLight()//맑은 날의 조명 비활성화
    {
        sunnyLight.SetActive(false);
    }
}
