using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScenesManager : MonoBehaviour
{
    public Image endingScene;       //�⺻ ����

    Image[] endingSceneArr = new Image[1];
    public static bool isEnding = false;

    void Start()
    {
        endingSceneArr = new Image[] { endingScene };
    }

    public void printEndingScene()
    {
        endingScene.gameObject.SetActive(true);
        isEnding = true;
    }
}
