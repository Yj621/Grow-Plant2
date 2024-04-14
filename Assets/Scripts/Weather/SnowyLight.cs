using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowyLight : MonoBehaviour
{
    public GameObject snowEffect;
    
    public void ActivateSnowEffect()
    {
        snowEffect.SetActive(true);
    }
    public void DeactivateSnowEffect()
    {
        snowEffect.SetActive(false);
    }
}
