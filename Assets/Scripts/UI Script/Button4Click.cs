using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button4Click : MonoBehaviour
{
    public TextMeshProUGUI button4Text;
    public int dateCount = 0;
    public static int snsUpload = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    private EventButtonUI eventButtonUI;
    public Button button4;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;
    public GameObject blockimg;
    private AudioManager audioManager;

    EndingScenesManager endingScenesManager;
    DiePanel diePanel;
    FadeInOut fadeInOut;
    MemoPanel memoPanel;

    string[] button4MemoArr =
        {
            "지렁이가 씨앗을 건드려서 악화됐다.",
            "다음날 식물이 응원을 받아 무럭무럭 자랐다.",
            "쾌적한 환경이 조성됐다.",
            "벌레를 잡다가 식물에 상처가 났다.",
            "식물을 돌보지 않아 식물의 상태가 악화됐다.",
            "식물에게는 별 도움이 되지 않는 행동에 식물의 상태가 악화됐다.",
            "진딧물을 잡아먹는 무당벌레를 죽였다.",
            "태풍을 피할 수 있었다.",
            "선글라스가 햇빛을 막아 식물의 상태가 악화됐다.",

        };

    void Start()
    {
        endingScenesManager = FindAnyObjectByType<EndingScenesManager>();
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindAnyObjectByType<DiePanel>();
        audioManager = FindAnyObjectByType<AudioManager>();
        dateCount = weatherUI.GetDateCount() + 1;

        string[] button4Arr = {
            "지렁이를 심는다","일광욕을 즐긴다", "응원한다", "제습제를 설치한다",
            "직접 죽인다","피크닉을 간다","SNS에 업로드한다","칭찬이 부족했나? 칭찬해주자",
            "뿌리도 잘 자라나 확인한다","죽인다","SNS에 업로드한다", "손으로 바로 세운다",
            "식물을 옮긴다", "SNS에 업로드한다", "선글라스를 씌운다", "SNS에 업로드한다", "강아지에게 간식을 준다",
            "응원한다", "SNS에 업로드한다", "뿌리를 자른다", "창문을 열다", "SNS에 업로드한다",
            "벌을 잡는다", "눈을 구경해 볼까?", "눈사람을 만든다", "선물을 요구한다", "떨어진 꽃잎을 줍는다",
            "SNS에 업로드한다", "SNS에 업로드한다"
        };

        string textValue = button4Arr[dateCount - 1];

        if (button4Text != null)
        {
            button4Text.text = textValue;
        }
        else
        {
            Debug.LogError("button4Text가 할당되지 않았습니다.");
        }
    }

    public void Button4OnClick()
    {
        blockimg.SetActive(true);
        StartCoroutine(Button4ClickSequence());

        //{}안에 있는 일차에 죽는 이벤트 발생
        int[] specialDateCounts = { 2, 8, 9, 12, 20, 21, 23, 24, 25, 26 };
        
        if (Array.IndexOf(specialDateCounts, dateCount) != -1)
        {
            diePanel.Btn4SpecialDied(dateCount);
        }
        
        eventButtonUI.ChangePopupInstancePosition();
    }

    private IEnumerator Button4ClickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();
        
        //일차별 버튼2 점수
        int[] btn4ScoreArr = {-10,-999,20,10,-20,-10,-5,-999,-999,-10,         //-999는 즉사, 999는 히든엔딩
            -5,-999,10,-5,-15,-5,0,0,-5,-999,
            -999,-5,-999,-999,-999,-999,0,-5,-5,0};    //30일차 4번 버튼에 들어갈 이벤트 필요
        //점수 더하기
        conditionUI.GetCondPoint(btn4ScoreArr[dateCount - 1]);

        weatherUI.SetDateCount();

        memoPanel.UpdateDayText();// +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 1)
        {
            memoPanel.contentText.text = button4MemoArr[0];
        }
        else if (dateCount == 3) 
        {
            memoPanel.contentText.text = button4MemoArr[1];
        }
        else if (dateCount == 4)
        {
            memoPanel.contentText.text = button4MemoArr[2];
        }
        else if (dateCount == 5)
        {
            memoPanel.contentText.text = button4MemoArr[3];
        }
        else if (dateCount == 6)
        {
            memoPanel.contentText.text = button4MemoArr[4];
        }
        else if (dateCount == 7 || dateCount == 11 || dateCount == 14 ||
            dateCount == 16 || dateCount == 18 || dateCount == 22 || dateCount == 28 || dateCount == 29)
        {
            memoPanel.contentText.text = button4MemoArr[5];
        }
        else if (dateCount == 10)
        {
            memoPanel.contentText.text = button4MemoArr[6];
        }
        else if (dateCount == 13)
        {
            memoPanel.contentText.text = button4MemoArr[7];
        }
        else if (dateCount == 15)
        {
            memoPanel.contentText.text = button4MemoArr[8];
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
            blockimg.SetActive(true);
            blockingBtn.CloseBlockingButton();
        }
        //waterCount 초기화
        button1Click.initWaterCount();

        //NeglectCount 초기화
        button2Click.initNeglectCount();
        
        //{}안에 있는 일차에 SNS에 업로드
        int[] uploadToSNSDate = { 7, 11, 14, 16, 19, 22, 28, 29 };

        //blockingBtn.CloseBlockingButton();
        if (Array.IndexOf(uploadToSNSDate, dateCount) != -1)
        {
            snsUpload++;
            Debug.Log("snsUplaod : " + snsUpload);
            if (snsUpload >= 5) 
            {
                endingScenesManager.printSNSEndingScene();
                EndingScenesManager.isEnding = true;
                audioManager.StopAllMusic(); //모든 음악 정지
                audioManager.backgroundMusic[7].Play();
            }
        }
    }
}
