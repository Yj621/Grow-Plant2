using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DateUI : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    //8일차 강아지
    public static bool isExecuted = false;
    //21일차 강아지
    public static bool isExecuted2 = false;

    DiePanel diePanel;

    void Start()
    {
        UpdateDayText();
        diePanel = FindAnyObjectByType<DiePanel>();


    }

    void Update()
    {
        if (isExecuted)
            return;

        // dateCount가 8인 경우에만 실행
        if (dateCount == 8 && !isExecuted)
        {
            RandomFunction();
        }

        // dateCount가 21인 경우에만 실행
        if (dateCount == 21 && !isExecuted2)
        {
            RandomFunction2();
        }
        Debug.Log("엔딩"+EndingScenesManager.isEnding);
    }

    public void IncreaseDateCount()
    {
        // 일 수를 증가시키는 메서드
        dateCount = weatherUI.GetDateCount();
        UpdateDayText();
    }

    void RandomFunction()
    {
        isExecuted = true;
        // 10%의 확률로 실행
        if (Random.Range(0, 100) < 10)
        {
            diePanel.SpecialDie(dateCount);
        }
    }
    void RandomFunction2()
    {
        isExecuted2 = true;
        // 15%의 확률로 실행
        if (Random.Range(0, 100) < 15)
        {
            diePanel.SpecialDie(dateCount);
        }
    }

    public void UpdateDayText()
    {
        dateCount = weatherUI.GetDateCount() + 1;
        // UI에 현재 일 수를 표시하는 메서드
        dayText.text = dateCount.ToString() + "DAY";
    }
}