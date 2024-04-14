using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScenesManager : MonoBehaviour
{
    public Image endingScene;       //기본 엔딩
    public Image snsEndingScene;    //꽃집사 인스타 머시기..
    public Image hiddenEndingScene; //그녀에게 꽃을 준다

    Image[] endingSceneArr = new Image[3];
    public static bool isEnding = false;

    void Start()
    {
        endingSceneArr = new Image[] { endingScene, hiddenEndingScene,snsEndingScene };
    }

    public void printEndingScene()
    {
        endingScene.gameObject.SetActive(true);
        isEnding = true;
    }
    public void printHiddenEndingScene()
    {
        hiddenEndingScene.gameObject.SetActive(true);
        isEnding = true;
    }

    public void printSNSEndingScene()
    {
        snsEndingScene.gameObject.SetActive(true);
        isEnding = true;
    }
}
