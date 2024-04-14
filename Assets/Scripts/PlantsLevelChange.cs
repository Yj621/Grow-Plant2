using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsLevelChange : MonoBehaviour
{
    int dateCount = 0;
    int condPoint = 0;
    public DateUI dateUI;
    public ConditionUI conditionUI;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;

    public GameObject sickLevel2;
    public GameObject sickLevel3;
    public GameObject sickLevel4;
    public GameObject sickLevel5;
    public GameObject sickLevel6;

    void Start()
    {        
        level1.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        level6.SetActive(false);
    }

    public void CheckDate()
    {
        dateCount = dateUI.dateCount + 1;
        condPoint = ConditionUI.conditionPoint;
        if (dateCount >= 0 && dateCount < 3)        //Level_1
        {
            level1.SetActive(true);
            level2.SetActive(false);
            level3.SetActive(false);
            level4.SetActive(false);
            level5.SetActive(false);
            level6.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);    
        }
        else if (dateCount >= 3 && dateCount < 7)   //Level_2
        {
            level1.SetActive(false);
            level3.SetActive(false);
            level4.SetActive(false);
            level5.SetActive(false);
            level6.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);
            if (condPoint > 40)
            {                
                level2.SetActive(true);
            }
            else
            {
                level2.SetActive(false);
                sickLevel2.SetActive(true);
            }
        }
        else if (dateCount >= 7 && dateCount < 11)  //Level_3
        {
            level1.SetActive(false);
            level2.SetActive(false);
            level4.SetActive(false);
            level5.SetActive(false);
            level6.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);
            if (condPoint > 40)
            {
                level3.SetActive(true);
            }
            else
            {
                level3.SetActive(false);
                sickLevel3.SetActive(true);
            }
        }
        else if (dateCount >= 11 && dateCount < 14) //Level_4
        {
            level1.SetActive(false);
            level2.SetActive(false);
            level3.SetActive(false);
            level5.SetActive(false);
            level6.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);
            if (condPoint > 40)
            {
                level4.SetActive(true);
            }
            else
            {
                level4.SetActive(false);
                sickLevel4.SetActive(true);
            }
        }
        else if (dateCount >= 14 && dateCount < 16) //Level_5
        {
            level1.SetActive(false);
            level2.SetActive(false);
            level3.SetActive(false);
            level4.SetActive(false);
            level6.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);
            if (condPoint > 40)
            {
                level5.SetActive(true);
            }
            else
            {
                level5.SetActive(false);
                sickLevel5.SetActive(true);
            }
        }
        else if (dateCount >= 16 && dateCount < 22) //Level_6
        {
            level1.SetActive(false);
            level2.SetActive(false);
            level3.SetActive(false);
            level4.SetActive(false);
            level5.SetActive(false);
            sickLevel2.SetActive(false);
            sickLevel3.SetActive(false);
            sickLevel4.SetActive(false);
            sickLevel5.SetActive(false);
            sickLevel6.SetActive(false);
            if (condPoint > 40)
            {
                level6.SetActive(true);
            }
            else
            {
                level6.SetActive(false);
                sickLevel6.SetActive(true);
            }
        }
    }
}
