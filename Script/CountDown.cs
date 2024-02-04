using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ajout de la référence au namespace UnityEngine.UI

public class CountDown : MonoBehaviour
{
    public float DurationTime = 0f;
    public GameObject FSaucer;
    private bool Once;
    public SwitchScene switchScene;
    public Text countdownText;

    public GameObject PausedCanvas;
    public Button PausedButton;
    public bool Pausedbool;
    // Start is called before the first frame update
    void Start()
    {
        Once = true;
        Pausedbool =true;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchScene.GameStarted)
        {
            DurationTime += Time.deltaTime;
            int durationTimeInt = Mathf.RoundToInt(DurationTime);
            countdownText.text = durationTimeInt.ToString() + " secondes";

            // Utilisation du modulo pour déclencher l'instantiation tous les 10 secondes
            if (durationTimeInt % 10 == 0)
            {
                if (Once)
                {
                    // Position explicite pour l'instantiation
                    Vector3 spawnPosition = transform.position + new Vector3(0f, -60f, 0f);
                    Quaternion spawnRotation = Quaternion.Euler(-90f, 90f, 0f);

                    // Instantiate avec position et rotation explicites
                    GameObject FlyingSaucer = Instantiate(FSaucer, spawnPosition, spawnRotation);

                    Once = false;
                }
            }
            else
            {
                Once = true;
            }
        }
    }

    public void Paused()
    {
        if(PausedButton.interactable)
        {
            Debug.Log("Clicked");
            if(Pausedbool)
            {
                Time.timeScale = 0f;
                Pausedbool = false;
                PausedCanvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                Pausedbool = true;
                PausedCanvas.SetActive(false);
            }
            
        }
    }
}
