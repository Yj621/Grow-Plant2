using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button3Click : MonoBehaviour
{
    public TextMeshProUGUI button3Text;
    public int dateCount = 0;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    private EventButtonUI eventButtonUI;
    public ConditionUI conditionUI;
    public BlockingButton blockingBtn;
    public Image endingImage;
    public EndingScenesManager endingScenesManager;
    public GameObject blockimg;
    private AudioManager audioManager;
    FadeInOut fadeInOut;
    MemoPanel memoPanel;
    private DiePanel diePanel;

    string[] button3MemoArr =
        {
            "따뜻한 곳에서 식물이 잘 자랄 것 같다.",
            "비가 들이쳐서 식물이 물을 많이 먹었다.",
            "벌레들이 사라졌다.",
            "화창한 날씨로 식물의 기분도 좋아졌다.",
            "쾌적한 환경으로 식물의 상태가 좋아졌다.",
            "무당벌레가 날아가 버렸다.",
            "젓가락으로 지지대를 세워 식물이 꺾이지 않았다.",
            "식물이 꺾이지 않고 똑바로 자랄 수 있게 되었다.",
            "햇빛을 많이 받아서 식물의 상태가 좋아졌다.",
            "잎에 벌레가 생기는 것을 예방할 수 있었다.",
            "습한 날씨에 가습기를 틀어 식물의 상태가 악화됐다.",
            "쾌적한 환경이 되어 식물의 상태가 좋아졌다.",
            "꽃가루 알레르기가 있다는 사실을 알아버렸다.",
            "따뜻한 곳으로 옮겨 식물의 상태가 좋아졌다.",
            "산타 할아버지가 영양제를 주고 가셨다.",
            "다 익지 않아 맛이 없었다."            
        };

    void Start()
    {
        eventButtonUI = FindAnyObjectByType<EventButtonUI>();
        fadeInOut = GameObject.FindObjectOfType<FadeInOut>();
        memoPanel = FindAnyObjectByType<MemoPanel>();
        diePanel = FindAnyObjectByType<DiePanel>();
        audioManager = FindAnyObjectByType<AudioManager>();
        dateCount = weatherUI.GetDateCount() + 1;

        string[] button3Arr = {
            "흙을 파본다", "식물을 옮긴다", "식물을 따뜻한 곳으로 옮긴다",
            "창문을 연다", "살충제를 뿌린다", "창문을 연다", "가습기를 튼다",
            "영양이 부족한가? 영양제를 주자", "가습기를 튼다", "가습기를 튼다",
            "가지치기한다", "무언가를 가져온다", "창문을 연다", "젓가락을 덧댄다",
            "햇볕에 옮긴다", "살충제를 뿌린다", "가습기를 튼다", "가습기를 튼다",
            "가습기를 튼다", "분갈이를 해준다", "가습기를 튼다", "꽃을 꺾어 그녀에게 준다",
            "살충제를 뿌린다", "식물을 옮긴다", "눈을 치운다", "정중하게 인사한다",
            "자책하며 식물을 버린다", "열매를 먹어본다", "열매를 먹어본다", 
            "열매를 딴다" //"열매 수확" 엔딩
        };
        string textValue = button3Arr[dateCount - 1];

        if (button3Text != null)
        {
            button3Text.text = textValue;
        }
        else
        {
            Debug.LogError("button3Text가 할당되지 않았습니다.");
        }
    }

    public void Button3OnClick()
    {
        blockimg.SetActive(true);
        
        StartCoroutine(Button3lickSequence());

        //{}안에 있는 일차에 죽는 이벤트 발생
        int[] specialDateCounts = { 1, 2, 11, 13, 21, 25, 27, 29 };
        
        if (Array.IndexOf(specialDateCounts, dateCount) != -1)
        {
            diePanel.Btn3SpecialDied(dateCount);
        }
        eventButtonUI.ChangePopupInstancePosition();
    }
    
    private IEnumerator Button3lickSequence()
    {
        yield return StartCoroutine(fadeInOut.FadeAlpha());
        //창닫기
        eventButtonUI.ClosePopupWindow();        

        //일차별 버튼3 점수
        int[] btn3ScoreArr = {-999,-999,3,-20,5,10,10,20,10,-10,  //-999는 즉사, 999는 히든엔딩
            -999,10,-999,10,10,10,10,-10,-10,10,
            -999,-5,-5,10,-999,10,-999,-20,-999,0};         //30일차에 엔딩(임시로 0점으로 해놓음)
        
        //점수 더하기
        conditionUI.GetCondPoint(btn3ScoreArr[dateCount - 1]);

        weatherUI.SetDateCount();

        //메모패널 콘텐츠텍스트
        memoPanel.UpdateDayText(); // +점수인지 -점수인지에 따라 메모패널 텍스트 변경(GetCondPoint보다 아래에 있어야 제대로 표시 가능)
        if (dateCount == 3)
        {
            memoPanel.contentText.text = button3MemoArr[0]; //memoPanel.UpdateDayText()보다 밑에 있어야 함.
        }
        else if (dateCount == 4)
        {
            memoPanel.contentText.text = button3MemoArr[1]; 
        }
        else if (dateCount == 5)
        {
            memoPanel.contentText.text = button3MemoArr[2]; 
        }
        else if (dateCount == 6)
        {
            memoPanel.contentText.text = button3MemoArr[3];
        }
        else if (dateCount == 7 || dateCount == 9 || dateCount == 17)
        {
            memoPanel.contentText.text = button3MemoArr[4]; 
        }
        else if (dateCount == 10 )
        {
            memoPanel.contentText.text = button3MemoArr[5];
        }
        else if (dateCount == 12)
        {
            memoPanel.contentText.text = button3MemoArr[6];
        }
        else if (dateCount == 14)
        {
            memoPanel.contentText.text = button3MemoArr[7];
        }
        else if (dateCount == 15)
        {
            memoPanel.contentText.text = button3MemoArr[8];
        }
        else if (dateCount == 16)
        {
            memoPanel.contentText.text = button3MemoArr[9];
        }
        else if (dateCount == 18 || dateCount == 19)
        {
            memoPanel.contentText.text = button3MemoArr[10];
        }
        else if (dateCount == 20)
        {
            memoPanel.contentText.text = button3MemoArr[11];
        }
        else if (dateCount == 22)
        {
            memoPanel.contentText.text = button3MemoArr[12];
        }
        else if (dateCount == 24)
        {
            memoPanel.contentText.text = button3MemoArr[13];
        }
        else if (dateCount == 26)
        {
            memoPanel.contentText.text = button3MemoArr[14];
        }
        else if (dateCount == 28)
        {
            memoPanel.contentText.text = button3MemoArr[15];
        }
        else if (dateCount == 30)
        {
            endingScenesManager.printEndingScene();
            EndingScenesManager.isEnding = true;
            audioManager.StopAllMusic(); //모든 음악 정지
            audioManager.backgroundMusic[5].Play();
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
            Debug.Log("close block");
            blockingBtn.CloseBlockingButton();
        }
              
        //waterCount 초기화
        button1Click.initWaterCount();

        //NeglectCount 초기화
        button2Click.initNeglectCount();

        //창닫기
        //blockingBtn.CloseBlockingButton();
    }
}
