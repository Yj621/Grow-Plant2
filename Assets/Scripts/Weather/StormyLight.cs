using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StormyLight : MonoBehaviour
{
    public GameObject stormEffect;
    public GameObject windZone;
    public GameObject stormWindZone;

    public void ActivateStormEffect()
    {
        stormEffect.SetActive(true);
    }
    public void DeactivateStormEffect()
    {
        stormEffect.SetActive(false);
    }
    public void ActivateStormWindZone()
    {
        stormWindZone.SetActive(true);
        windZone.SetActive(false);
    }
    public void DeactivateStormWindZone()
    {
        stormWindZone.SetActive(false);
        windZone.SetActive(true);
    }   
}
