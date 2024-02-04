using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public bool GameStarted;
    public Button ButtonStart;
    public GameObject Canvas;
    public GameObject PausedCanvas;
    void Start()
    {
        
    }

    public void OnClick()
    {
        if(ButtonStart.interactable)
        {
            GameStarted = true;
            Canvas.SetActive(false);
            PausedCanvas.SetActive(true);
        }
    }

}
