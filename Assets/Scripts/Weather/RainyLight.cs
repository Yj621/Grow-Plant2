using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainyLight : MonoBehaviour
{
    public GameObject rainyLight;
    public GameObject rainEffect;

    public void ActivateRainEffect() //�� ���� ���� ���� Ȱ��ȭ
    {
        rainEffect.SetActive(true);
    }

    public void DeactivateRainEffect()//�� ���� ���� ���� ��Ȱ��ȭ
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
