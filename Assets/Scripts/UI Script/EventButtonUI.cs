using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventButtonUI : MonoBehaviour
{
    public GameObject popupWindow;
    public Transform eventCanvas; // EventCanvas

    private bool isPopupOpen = false;
    
    private GameObject popupInstance;    
    public GameObject selectPopupClone; 
    private Vector3 originalPosition; // 원래 위치를 저장하기 위함
    SoundManager soundManager;
    TouchManager touchManager;

    void Start()
    {
        if (popupWindow != null)
            popupWindow.SetActive(false);
        soundManager = FindAnyObjectByType<SoundManager>();
        touchManager = FindAnyObjectByType<TouchManager>();
        // 시작할 때 원래 위치를 저장
        if (selectPopupClone != null)
        {
            originalPosition = selectPopupClone.transform.position;
        }
    }

    public void OpenPopupWindow()
    {
        if (isPopupOpen)
        {
            return;
        }

        if (eventCanvas != null)
        {
            Vector3 centerScreenPosition = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

            popupInstance = Instantiate(popupWindow, centerScreenPosition, Quaternion.identity, eventCanvas);
            popupInstance.SetActive(true);

            isPopupOpen = true;
        }
        else
        {
            Debug.LogError("Null eventCanvas");
        }
        touchManager.isPanelActive = true;
    }

    public void ClosePopupWindow()
    {
        if (!isPopupOpen)
        {
            return;
        }
        if (popupInstance != null)
        {
            Destroy(popupInstance);
        }
        isPopupOpen = false;
        soundManager.Sound(2);
        touchManager.isPanelActive = false;
    }

    public void ChangePopupInstancePosition()
    {
        if (selectPopupClone != null)
        {
            // 새 위치 설정
            Vector3 newPosition = selectPopupClone.transform.position;
            newPosition.x = 5000f;
            selectPopupClone.transform.position = newPosition;
        }
    }

    // 원래 위치로 돌아가는 메서드
    public void RestoreOriginalPosition()
    {
        if (selectPopupClone != null)
        {
            // 원래 위치로 복원
            selectPopupClone.transform.position = originalPosition;
        }
    }
}
