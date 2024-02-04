using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationQuit : MonoBehaviour
{
    public Button QuitButton;
    
    public void OnClick()
    {
        if(QuitButton.interactable)
        {
            Application.Quit();
        }
    }
}
