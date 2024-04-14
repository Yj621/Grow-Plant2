using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button2Click : MonoBehaviour
{
    public TextMeshProUGUI button2Text;
    public int dateCount = 0;
    private static int NeglectCount;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;
    public EndingScenesManager endingScenesManager;
    public GameObject blockimg;
    private AudioManager audioManager;

    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    GameManager gameManager;
    DiePanel diePanel;

    string[] button2MemoArr = {
            "진딧물이 생겼다.",
            "잎에 벌레가 생겼다."
        };

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        gameManager = FindObjectOfType<GameManager>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindObjectOfType<DiePanel>();
        audioManager = FindAnyObjectByType<AudioManager>();
        dateCount = weatherUI.GetDateCount() + 1;
        
        string[] button2Arr = {
            "냅둔다",          
            "습도가 높은 것 같다. 확인해보자",
            "꽃을 꺾어 그녀에게 준다",
            "가습기를 튼다",
            "경찰에 신고한다"
        };
        string textValue;
        if (dateCount == 8)
        {
            textValue = button2Arr[1];
        }
        else if (dateCount == 22)
        {
            textValue = button2Arr[2];            
        }
        else if (dateCount == 25)
        {
            textValue = button2Arr[3];
        }
        else if (dateCount == 26)
        {
            textValue = button2Arr[4];
        }
        else
        {
            textValue = button2Arr[0];
        }

        if (button2Text != null)
        {
            button2Text.text = textValue;
        }
        else
        {
            Debug.LogError("button2Text가 할당되지 않았습니다.");
        }
    }

    public void Button2OnClick()
    {
        blockimg.SetActive(true);
        
        StartCoroutine(Button2ClickSequence());

        //{}안에 있는 일차에 죽는 이벤트 발생
        int[] specialDateCounts = { 5, 8, 12, 13, 14, 21, 23, 24, 26, 30 };
        
        if (Array.IndexOf(specialDateCounts, dateCount) != -1)
        {
            diePanel.Btn2SpecialDied(dateCount);
        }
        eventButtonUI.ChangePopupInstancePosition();
    }
    private IEnumerator Button2ClickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();
        
        
        NeglectCount++;
        Debug.Log("NeglectCount : "+NeglectCount);
        if (NeglectCount >= 3)
        {
            diePanel.PanelOn();
            diePanel.isDie = true;
            diePanel.diedText.text = "식물을 오랫동안 방치해서 죽었습니다.";
        }

        //일차별 버튼2 점수
        int[] btn2ScoreArr = {0,0,0,10,-999,0,0,-999,0,0,        //-999는 즉사, 999는 히든엔딩
            10,-999,-999,-999,5,-10,0,0,0,-5,
            -999,999,-999,-999,5,-999,0,0,0,-999};                                       //
        //점수 더하기
        conditionUI.GetCondPoint(btn2ScoreArr[dateCount-1]);

        weatherUI.SetDateCount();

        memoPanel.UpdateDayText();// +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 11)
        {
            memoPanel.contentText.text = button2MemoArr[0]; //memoPanel.UpdateDayText()보다 밑에 있어야 함.
        }
        else if (dateCount == 16)
        {
            memoPanel.contentText.text = button2MemoArr[1]; 
        }
        else if (dateCount == 22)
        {
            endingScenesManager.printHiddenEndingScene();
            EndingScenesManager.isEnding = true;
            audioManager.StopAllMusic(); //모든 음악 정지
            audioManager.backgroundMusic[6].Play();
        }

        if (diePanel.isDie == false && EndingScenesManager.isEnding == false)
        {
            //메모패널 열기 
            memoPanel.MemoPanelOn();
            blockimg.SetActive(false);
            eventButtonUI.RestoreOriginalPosition();
        }
        else
        {
            Debug.Log("close block");
            blockingBtn.CloseBlockingButton();
            blockimg.SetActive(true);
        }

        //waterCount 초기화
        button1Click.initWaterCount();

        //blockingBtn.CloseBlockingButton();
    }
    public int initNeglectCount()
    {
        NeglectCount = 0;
        return NeglectCount; //다른 버튼이 눌릴 시 NeglectCount 0으로 초기화
    }
}
