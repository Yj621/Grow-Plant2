using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunnyLight : MonoBehaviour
{
    public GameObject sunnyLight;

    public void ActivateSunnyLight() //���� ���� ���� Ȱ��ȭ
    {
        sunnyLight.SetActive(true);
    }

    public void DeactivateSunnyLight()//���� ���� ���� ��Ȱ��ȭ
    {
        sunnyLight.SetActive(false);
    }
}
