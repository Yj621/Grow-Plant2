using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class WeatherUI : MonoBehaviour
{
    public TextMeshProUGUI weatherText;
    public int date = 0; // 이벤트를 하나씩 넘길 때마다 date++
    string originWeatherText;
    public DateUI dateUI;
    public SunnyLight sunnyLight;
    public RainyLight rainyLight;
    public StormyLight stormyLight;
    public SnowyLight snowyLight;
    public PlantsLevelChange plantsLevelChange;
    public AudioManager audioManager;


    void Start()
    {
        originWeatherText = weatherText.text;  // "날씨 : "를 저장하는 변수
        string[] weatherArr = {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "태풍", "맑음", "맑음", "맑음", "습함",
            "습함", "비", "맑음", "맑음", "흐림", "눈", "눈", "맑음", "맑음",
            "흐림", "비", "맑음"
        };

        string textValue = weatherArr[date];

        if (weatherText != null)
        {
            // 기존 텍스트 초기화 후 새로운 텍스트 설정
            weatherText.text += textValue;
        }
        else
        {
            Debug.LogError("weatherArr가 할당되지 않았습니다.");
        }
    }

    public void WeatherTextUpdate()
    {
        // 이벤트를 하나씩 넘길 때마다 텍스트 업데이트
        string[] textLines = new string[] {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "태풍", "맑음", "맑음", "맑음", "습함",
            "습함", "비", "맑음", "맑음", "흐림", "눈", "눈", "맑음", "맑음",
            "흐림", "비", "맑음"
        };

        // 경계를 초과하지 않도록 조건 추가
        if (date < textLines.Length)
        {
            string textValue = textLines[date];

            if (weatherText != null)
            {
                // 기존 텍스트 초기화 후 새로운 텍스트 추가
                weatherText.text = originWeatherText;
                weatherText.text += textValue;
            }
            else
            {
                Debug.LogError("weatherText가 할당되지 않았습니다.");
            }
        }
        else
        {
            Debug.LogWarning("더 이상 텍스트가 없습니다.");
        }
    }
    public void WeatherLightUpdate()
    {
        /*
        0 배경음악
        1 비
        2 태풍
        3 눈
        4 흐림
        5 찐엔딩
        6 꽃엔딩
        7 인스타엔딩
        */

        string[] textLines = new string[] {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "태풍", "맑음", "맑음", "맑음", "습함",
            "습함", "비", "맑음", "맑음", "흐림", "눈", "눈", "맑음", "맑음",
            "흐림", "비", "맑음"
        };

        if (textLines[date] == "맑음")
        {
            sunnyLight.ActivateSunnyLight();    //맑은 날의 조명 활성화
            rainyLight.DeactivateCloudyLight(); //흐린 날의 조명 비활성화
            rainyLight.DeactivateRainEffect();  //Rain Effect 비활성화
            stormyLight.DeactivateStormEffect();
            stormyLight.DeactivateStormWindZone();
            snowyLight.DeactivateSnowEffect();
            // 배경 음악이 재생 중이면 정지
            if (audioManager.backgroundMusic[1].isPlaying || 
                audioManager.backgroundMusic[2].isPlaying || 
                audioManager.backgroundMusic[3].isPlaying || 
                audioManager.backgroundMusic[4].isPlaying)
            {
                TurnOnMusic0();
            }
            else if (!audioManager.backgroundMusic[0].isPlaying ||
                    !audioManager.backgroundMusic[1].isPlaying ||
                    !audioManager.backgroundMusic[2].isPlaying ||
                    !audioManager.backgroundMusic[3].isPlaying ||
                    !audioManager.backgroundMusic[4].isPlaying)
            {
                audioManager.currentIndex = 0;
            }
        }
        else if (textLines[date] == "흐림")
        {
            sunnyLight.DeactivateSunnyLight();  //맑은 날의 조명 비활성화
            rainyLight.ActivateCloudyLight();   //비 오는 날의 조명 활성화
            rainyLight.DeactivateRainEffect();  //Rain Effect 비활성화
            stormyLight.DeactivateStormEffect();
            stormyLight.DeactivateStormWindZone();
            snowyLight.DeactivateSnowEffect();
            // 배경 음악이 재생 중이면 정지
            if (audioManager.backgroundMusic[0].isPlaying || 
                audioManager.backgroundMusic[1].isPlaying ||
                audioManager.backgroundMusic[2].isPlaying || 
                audioManager.backgroundMusic[3].isPlaying || 
                audioManager.backgroundMusic[4].isPlaying)
            {
                TurnOnMusic4();
            }
            else if (!audioManager.backgroundMusic[0].isPlaying ||
                    !audioManager.backgroundMusic[1].isPlaying ||
                    !audioManager.backgroundMusic[2].isPlaying ||
                    !audioManager.backgroundMusic[3].isPlaying ||
                    !audioManager.backgroundMusic[4].isPlaying)
            {
                audioManager.currentIndex = 4;
            }
        }
        else if (textLines[date] == "비")
        {
            sunnyLight.DeactivateSunnyLight();  //맑은 날의 조명 비활성화
            rainyLight.ActivateCloudyLight();   //비 오는 날의 조명 활성화
            rainyLight.ActivateRainEffect();    //Rain Effect 활성화
            stormyLight.DeactivateStormEffect();
            stormyLight.DeactivateStormWindZone();
            snowyLight.DeactivateSnowEffect();
            if (audioManager.backgroundMusic[0].isPlaying || 
                audioManager.backgroundMusic[1].isPlaying ||
                audioManager.backgroundMusic[2].isPlaying || 
                audioManager.backgroundMusic[3].isPlaying || 
                audioManager.backgroundMusic[4].isPlaying)
            {
                TurnOnMusic4();
            }
            else if (!audioManager.backgroundMusic[0].isPlaying ||
                    !audioManager.backgroundMusic[1].isPlaying ||
                    !audioManager.backgroundMusic[2].isPlaying ||
                    !audioManager.backgroundMusic[3].isPlaying ||
                    !audioManager.backgroundMusic[4].isPlaying)
            {
                audioManager.currentIndex = 4;
            }
        }
        else if (textLines[date] == "태풍")
        {
            sunnyLight.DeactivateSunnyLight();  //맑은 날의 조명 비활성화
            rainyLight.ActivateCloudyLight();   //비 오는 날의 조명 활성화
            rainyLight.DeactivateRainEffect();
            snowyLight.DeactivateSnowEffect();
            stormyLight.ActivateStormEffect();
            stormyLight.ActivateStormWindZone();
            if (audioManager.backgroundMusic[0].isPlaying || 
                audioManager.backgroundMusic[1].isPlaying ||
                audioManager.backgroundMusic[2].isPlaying || 
                audioManager.backgroundMusic[3].isPlaying || 
                audioManager.backgroundMusic[4].isPlaying)
            {
                TurnOnMusic2();
            }
            else if (!audioManager.backgroundMusic[0].isPlaying ||
                     !audioManager.backgroundMusic[1].isPlaying ||
                     !audioManager.backgroundMusic[2].isPlaying ||
                     !audioManager.backgroundMusic[3].isPlaying ||
                     !audioManager.backgroundMusic[4].isPlaying)
            {
                audioManager.currentIndex = 2;
            }
        }
        else if (textLines[date] == "눈")
        {
            sunnyLight.DeactivateSunnyLight();
            rainyLight.ActivateCloudyLight();
            rainyLight.DeactivateRainEffect();
            stormyLight.DeactivateStormEffect();
            stormyLight.DeactivateStormWindZone();
            snowyLight.ActivateSnowEffect();
            if (audioManager.backgroundMusic[0].isPlaying || 
                audioManager.backgroundMusic[1].isPlaying ||
                audioManager.backgroundMusic[2].isPlaying || 
                audioManager.backgroundMusic[3].isPlaying || 
                audioManager.backgroundMusic[4].isPlaying)
            {
                TurnOnMusic3();
            }
            else if(!audioManager.backgroundMusic[0].isPlaying ||
                    !audioManager.backgroundMusic[1].isPlaying ||
                    !audioManager.backgroundMusic[2].isPlaying ||
                    !audioManager.backgroundMusic[3].isPlaying ||
                    !audioManager.backgroundMusic[4].isPlaying)
            {
                audioManager.currentIndex = 3;
            }
        }
    }

    public int GetDateCount()
    {
        return date;
    }

    public void SetDateCount()
    {
        date += 1;

        //일수가 늘어난 후 일차에 따라 식물 레벨 체크
        plantsLevelChange.CheckDate();

        string[] textLines = new string[] {
            "맑음", "맑음", "흐림", "비", "비", "맑음", "맑음", "맑음", "건조함",
            "맑음", "맑음", "흐림", "태풍", "태풍", "맑음", "맑음", "맑음", "습함",
            "습함", "비", "맑음", "맑음", "흐림", "눈", "눈", "맑음", "맑음",
            "흐림", "비", "맑음"
        };

        WeatherTextUpdate();

        dateUI.IncreaseDateCount();
        
        WeatherLightUpdate();
    }
    
    private void TurnOnMusic0() //맑음 날씨
    {
        // 배경 음악 정지
        audioManager.backgroundMusic[1].Stop();
        audioManager.backgroundMusic[2].Stop();
        audioManager.backgroundMusic[3].Stop();
        audioManager.backgroundMusic[4].Stop();
        // currentIndex를 0으로 설정하여 맑은 날 배경 음악 재생
        audioManager.currentIndex = 0;
        audioManager.backgroundMusic[audioManager.currentIndex].Play();
    }
    private void TurnOnMusic4() //흐림, 비 날씨
    {
        audioManager.backgroundMusic[0].Stop();
        audioManager.backgroundMusic[2].Stop();
        audioManager.backgroundMusic[3].Stop();
        audioManager.currentIndex = 4;
        audioManager.backgroundMusic[audioManager.currentIndex].Play();
    }
    private void TurnOnMusic2() //태풍 날씨
    {
        audioManager.backgroundMusic[0].Stop();
        audioManager.backgroundMusic[3].Stop();
        audioManager.backgroundMusic[4].Stop();
        audioManager.currentIndex = 2;
        audioManager.backgroundMusic[audioManager.currentIndex].Play();
    }
    private void TurnOnMusic3() //눈 날씨
    {
        audioManager.backgroundMusic[0].Stop();
        audioManager.backgroundMusic[1].Stop();
        audioManager.backgroundMusic[2].Stop();
        audioManager.backgroundMusic[4].Stop();
        audioManager.currentIndex = 3;
        audioManager.backgroundMusic[audioManager.currentIndex].Play();
    }
}
