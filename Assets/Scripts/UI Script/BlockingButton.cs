using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockingButton : MonoBehaviour
{
    public GameObject blockingBtn;
 
    void Start()
    {
        if (blockingBtn != null)
            blockingBtn.SetActive(false);
    }
    public void OpenBlockingButton()
    {
        blockingBtn.SetActive(true);
    }

    public void CloseBlockingButton()
    {
        blockingBtn.SetActive(false);
    }
}
