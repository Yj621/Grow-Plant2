using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button1Click : MonoBehaviour
{
    public TextMeshProUGUI button1Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    private EventButtonUI eventButtonUI;
    public Button2Click button2Click;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;
    public GameObject blockimg;

    public static int waterCount;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    GameManager gameManager;
    DiePanel diePanel;

    string[] button1MemoArr =
        {
            "습한데 물을 줘서 식물이 비실해졌다.",
            "습한 날씨에 물을 줘서 식물 상태가 악화됐다.",
            "뿌리에 습기가 가득 찼다."
        };

    void Start()
    {
        memoPanel = FindAnyObjectByType<MemoPanel>();
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        diePanel = FindAnyObjectByType<DiePanel>();
        dateCount = weatherUI.GetDateCount() + 1;
        gameManager = FindObjectOfType<GameManager>();
      
        string[] button1Arr = {
            "물을 준다",
            "냉/난방기 때문인 것 같다. 끄자",
            "열매를 심는다"
        };
        string textValue;
        if (dateCount == 8)  //dateCount는 일차를 나타냄. 8일차, 16일차에는 txt파일의 각각 2번째 줄과 3번째 줄의 내용을 넣음.
        {
            textValue = button1Arr[1];
        }
        else if (dateCount == 30)
        {
            textValue = button1Arr[2];
        }
        else
        {
            textValue = button1Arr[0];
        }

        if (button1Text != null)
        {
            button1Text.text = textValue;
        }
        else
        {
            Debug.LogError("button1Text가 할당되지 않았습니다.");
        }
    }

    public void Button1OnClick()
    {
        
        StartCoroutine(Button1ClickSequence()); 
        
        //{}안에 있는 일차에 죽는 이벤트 발생
        int[] specialDateCounts = { 8, 14, 24, 30};
        
        if (Array.IndexOf(specialDateCounts, dateCount) != -1)
        {
            diePanel.Btn1SpecialDied(dateCount);
        }
        eventButtonUI.ChangePopupInstancePosition();
    }
    
    private IEnumerator Button1ClickSequence()
    {
   
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();

        waterCount++;

        Debug.Log("waterCount : "+waterCount);
        if (waterCount >= 5)
        {
            diePanel.PanelOn();
            diePanel.isDie = true;
            diePanel.diedText.text = "물을 너무 많이 주어서 식물이 죽었습니다.";
        }

        //일차별 버튼1 점수
        int[] btn1ScoreArr = {5,5,5,-5,5,5,10,-999,5,5,      //-999는 즉사
            10,5,-5,-999,5,5,5,-10,-10,-15,
            10,5,5,-999,5,5,5,5,5,0};           //4일차 1번 버튼은 습한데 물을 많이 줘서 비실해짐 -50
        //점수 더하기
        conditionUI.GetCondPoint(btn1ScoreArr[dateCount - 1]);

        weatherUI.SetDateCount();

        memoPanel.UpdateDayText();// +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 4)
        {
            memoPanel.contentText.text = button1MemoArr[0]; //memoPanel.UpdateDayText()보다 밑에 있어야 함.
        }
        else if (dateCount == 18 || dateCount == 19)
        {
            memoPanel.contentText.text = button1MemoArr[1];
        }
        else if (dateCount == 20)
        {
            memoPanel.contentText.text = button1MemoArr[2];
        }

        if (diePanel.isDie == false)
        {
            //메모패널 열기 
            memoPanel.MemoPanelOn();

            //NeglectCount 초기화
            button2Click.initNeglectCount();

            // blockingBtn.CloseBlockingButton();
            blockimg.SetActive(false);
            eventButtonUI.RestoreOriginalPosition();
        }
        else
        {
            Debug.Log("close block");
            blockingBtn.CloseBlockingButton();
            blockimg.SetActive(true);
        }
    }

    public int initWaterCount()
    {
        waterCount = 0;
        return waterCount; //다른 버튼이 눌릴 시 waterCount를 0으로 초기화
    }

}
