using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject blockingImg;    
    public GameObject quitPanel;
    public ConditionUI conditionUI;
    public DateUI dateUI;
    public EventTextUI eventTextUI;
    public EventButtonUI eventButtonUI;
    public FadeInOut fadeInOut;
    public TouchManager touchManager;
    public WeatherUI weatherUI;
    public Button1Click button1Click;
    public Button2Click button2Click;
    public Button3Click button3Click;
    public Button4Click button4Click;
    public Notice _notice;
    public PlantsLevelChange plantsLevelChange;
    public DiePanel diePanel;

    void Start()
    {
        GameLoad();

        //처음 시작할 때만 50점으로 초기화
        if (ConditionUI.conditionPoint <= 0)
        {
            ConditionUI.conditionPoint = 50;
        }
        
        dateUI.UpdateDayText();
        conditionUI.ReturnCondPoint();
        weatherUI.WeatherTextUpdate();
        weatherUI.WeatherLightUpdate();
        blockingImg.SetActive(false);
        quitPanel.SetActive(false);       
    }
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                OpenQuitPanel();
            }
        }
    }
    // public void Retry()
    // {
	//     SceneManager.LoadScene(0);
    // }
    public void OpenQuitPanel()
    {
        quitPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameSave()
    {
        PlayerPrefs.SetInt("ConditionPoint", ConditionUI.conditionPoint);
        PlayerPrefs.SetInt("Button1Click", button1Click.dateCount);
        PlayerPrefs.SetInt("Button2Click", button2Click.dateCount);
        PlayerPrefs.SetInt("Button3Click", button3Click.dateCount);
        PlayerPrefs.SetInt("Button4Click", button4Click.dateCount);
        PlayerPrefs.SetInt("EventTextUI", eventTextUI.dateCount);  
        PlayerPrefs.SetInt("DateUI", dateUI.dateCount);  
        PlayerPrefs.SetInt("WeatherUI", weatherUI.date);  
        PlayerPrefs.Save();
        _notice.SUB("저장되었습니다.");
    }
    public void GameLoad()
    {
        int conditionPoint = PlayerPrefs.GetInt("ConditionPoint");
        int dateCount1 = PlayerPrefs.GetInt("Button1Click");
        int dateCount2 = PlayerPrefs.GetInt("Button2Click");
        int dateCount3 = PlayerPrefs.GetInt("Button3Click");
        int dateCount4 = PlayerPrefs.GetInt("Button4Click");
        int dateCount5 = PlayerPrefs.GetInt("EventTextUI");
        int dateCount6 = PlayerPrefs.GetInt("DateUI");
        int date = PlayerPrefs.GetInt("WeatherUI");

        ConditionUI.conditionPoint = conditionPoint;
        button1Click.dateCount = dateCount1;
        button2Click.dateCount = dateCount2;
        button3Click.dateCount = dateCount3;
        button4Click.dateCount = dateCount4;
        eventTextUI.dateCount = dateCount5;
        dateUI.dateCount = dateCount6;
        weatherUI.date = date;
    }
    public void Restart()
    {
        //변수 초기화
        ConditionUI.conditionPoint = 50;    //conditionPoint 초기화
        button1Click.initWaterCount();      //waterCount 초기화
        button2Click.initNeglectCount();    //neglectCount 초기화
        dateUI.dateCount = 0;
        weatherUI.date = 0;
        DateUI.isExecuted = false;
        DateUI.isExecuted2 = false;
        EndingScenesManager.isEnding = false;
        diePanel.isDie = false;

        dateUI.UpdateDayText();
        conditionUI.ReturnCondPoint();
        weatherUI.WeatherTextUpdate();
        weatherUI.WeatherLightUpdate();
        plantsLevelChange.CheckDate();
    }
}