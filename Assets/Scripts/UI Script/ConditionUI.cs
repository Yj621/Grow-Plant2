using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConditionUI : MonoBehaviour
{
    public static int conditionPoint = 50;
    public TextMeshProUGUI conditionText;
    string originConditionText = "식물상태 : ";    
    public GameObject blockingImg;
    private int newPoint = 0;
    private int maxPoint = 100;
    public bool isGood = false;
    public bool isSoso = false;
    public bool isBad = false;

    DiePanel diePanel;

    void Start()
    {   
        UpdateConditionText();
        diePanel = FindAnyObjectByType<DiePanel>();
    }
    
    private void UpdateConditionText() //식물상태가 점수에 따라서 바뀌게 함.
    {
        string currentCond = "";
        if (conditionPoint <= 0)
        {
            diePanel.PanelOn(); //식물이 죽었을 때(점수가 0점 이하로 떨어짐)
            blockingImg.SetActive(true);
        }
        else
        {
            if (conditionPoint > 90 && conditionPoint <= 100)
            {
                currentCond = "정말 많이 좋음";
            }
            else if (conditionPoint > 80 && conditionPoint <= 90)
            {
                currentCond = "매우 좋음";
            }
            else if (conditionPoint > 70 && conditionPoint <= 80)
            {
                currentCond = "좋음";
            }
            else if (conditionPoint > 60 && conditionPoint <= 70)
            {
                currentCond = "좋아지려 함";
            }
            else if (conditionPoint > 40 && conditionPoint <= 60)
            {
                currentCond = "보통";
            }
            else if (conditionPoint > 30 && conditionPoint <= 40)
            {
                currentCond = "나빠지려 함";
            }
            else if (conditionPoint > 20 && conditionPoint <= 30)
            {
                currentCond = "나쁨";
            }
            else if (conditionPoint > 10 && conditionPoint <= 20)
            {
                currentCond = "매우 나쁨";
            }
            else if (conditionPoint <= 10)
            {
                currentCond = "죽으려 함";
            }
            conditionText.text = originConditionText;
            conditionText.text += currentCond;
        }
    }


    private void SetCondPoint(int newPoint)
    {
        conditionPoint = newPoint;
        UpdateConditionText();
        Debug.Log("conditionPoint: " + conditionPoint);
    }

    //버튼을 누르면 배열 안의 점수를 가져오는 메서드
    public void GetCondPoint(int point) 
    {
        newPoint = conditionPoint + point;
        if (newPoint > 100)
        {
            newPoint = maxPoint;
        }
        SetCondPoint(newPoint);
        if(point > 0)
        {
            isGood = true;
        }
        else if(point == 0)
        {
            isSoso = true;
        }
        else
        {
            isBad = true;
        }
    }
    public int ReturnCondPoint()
    {
        UpdateConditionText();
        return conditionPoint;
    }
}
