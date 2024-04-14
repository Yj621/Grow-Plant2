using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] arrAudio;
    // 효과음 상태 변수
    private bool[] soundStates;

    void Start()
    {
        // 효과음 상태 초기화
        soundStates = new bool[arrAudio.Length];
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = true; // 기본적으로 모든 효과음을 켭니다.
        } 
    }

    /*
    0 클릭(버튼)
    1 패널온
    2 패널 오프
    3 식물 자라기
    4 식물 시들기
    5 죽기
    */
    public void Sound(int arr) 
    {
        // 소리가 켜져 있는지 확인
        if (soundStates[arr])
        {
            arrAudio[arr].Play();
        }
    }

    // 모든 효과음 켜기
    public void TurnOnAllSounds()
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = true;
        }
    }

    // 모든 효과음 끄기
    public void TurnOffAllSounds()
    {
        for (int i = 0; i < arrAudio.Length; i++)
        {
            soundStates[i] = false;
        }
    }

    // 효과음 볼륨 일괄 업데이트
    public void UpdateEffectsVolume(float volume)
    {
        foreach (AudioSource audioSource in arrAudio)
        {
            audioSource.volume = volume;
        }
    }
}
