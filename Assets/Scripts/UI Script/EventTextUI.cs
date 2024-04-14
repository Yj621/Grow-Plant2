using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTextUI : MonoBehaviour
{
    public TextMeshProUGUI eventText;
    public int dateCount = 0;
    public WeatherUI weatherUI;

    void Start()
    {
        OpenEvent();
    }

    public void OpenEvent()
    {
        string[] eventTextArr = {
            "흙이 말라있다", "해가 쨍쨍하다", "싹이 나오기 시작했다",
            "비가 내려 습하다", "습해서 벌레가 많이 생겼다", "날씨가 화창하다",
            "싹이 텄다", "식물이 시들었다. 이유를 찾자", "식물이 잘 자라고 있다",
            "무당벌레가 찾아왔다", "줄기가 자랐다", "줄기가 조금 휜 것 같다",
            "태풍이 일어났다", "줄기가 점점 길어진다", "햇빛이 강하다",
            "잎이 자랐다", "요즈음 모르는 강아지가 주변을 맴돈다", "봉오리가 생길 듯 하다",
            "봉오리가 생겼다", "화분에 뿌리가 가득 찼다","꽃에서 단내가 난다","꽃이 폈다",
            "꽃에 꿀벌이 앉았다","눈이 내린다","눈이 쌓였다","산타할아버지가 찾아오셨다",
            "꽃이 졌다","열매가 생겼다","열매의 색이 진해진다","열매가 다 자랐다"
            };

        dateCount = weatherUI.GetDateCount();
        string textValue = eventTextArr[dateCount];

        eventText.text = textValue;

    }
}
