using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowMovement : MonoBehaviour
{
    public float vitesseDeplacement;
    private float rotationSpeed = 100f;
    private string previousButton;
    private bool ButtonEnfonce1;
    private bool ButtonEnfonce2;

    private bool ButtonEnfonce3;

    private bool ButtonEnfonce4;
    public bool IsPausedGame;
    public GameObject Lose;
    public int TimeSaved;
    public Text Score;

    public CountDown countdown;

    public SwitchScene switchScene;

    // Start is called before the first frame update
    void Start()
    {
        ButtonEnfonce2 = true;
        ButtonEnfonce3 = true;
        ButtonEnfonce1 = true;   
        ButtonEnfonce4 = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(switchScene.GameStarted)
        {
            if(!IsPausedGame)
            {
                // Mouvement basé sur les touches fléchées
                if (Input.GetKey(KeyCode.LeftArrow)&& ButtonEnfonce1)
                {
                    transform.Translate(Vector3.left * vitesseDeplacement * Time.deltaTime);
                    previousButton = "Left";
                    CancelInvoke("Button2");
                    CancelInvoke("Button3");
                    CancelInvoke("Button4");
                    ButtonEnfonce2 = false;
                    ButtonEnfonce3 = false;
                    ButtonEnfonce4 = false;
                    Invoke("Button2",0.1f);
                    Invoke("Button3",0.1f);
                    Invoke("Button4",0.1f);


                }

                if (Input.GetKey(KeyCode.RightArrow)&& ButtonEnfonce2)
                {
                    transform.Translate(Vector3.right * vitesseDeplacement * Time.deltaTime);
                    previousButton = "Right";
                    CancelInvoke("Button1");
                    CancelInvoke("Button3");
                    CancelInvoke("Button4");
                    ButtonEnfonce1 = false;
                    ButtonEnfonce3 = false;
                    ButtonEnfonce4 = false;
                    Invoke("Button1",0.1f);
                    Invoke("Button3",0.1f);
                    Invoke("Button4",0.1f);
                }

                if (Input.GetKey(KeyCode.DownArrow)&& ButtonEnfonce3)
                {
                    transform.Translate(Vector3.back * vitesseDeplacement * Time.deltaTime);
                    previousButton = "autre";
                    CancelInvoke("Button2");
                    CancelInvoke("Button1");
                    CancelInvoke("Button4");
                    ButtonEnfonce2 = false;
                    ButtonEnfonce1 = false;
                    ButtonEnfonce4 = false;
                    Invoke("Button2",0.1f);
                    Invoke("Button1",0.1f);
                    Invoke("Button4",0.1f);
                }

                if (Input.GetKey(KeyCode.UpArrow)&& ButtonEnfonce4)
                {
                    transform.Translate(Vector3.forward * vitesseDeplacement * Time.deltaTime);
                    previousButton = "autre";
                    CancelInvoke("Button2");
                    CancelInvoke("Button3");
                    CancelInvoke("Button1");
                    ButtonEnfonce2 = false;
                    ButtonEnfonce3 = false;
                    ButtonEnfonce1 = false;
                    Invoke("Button2",0.1f);
                    Invoke("Button3",0.1f);
                    Invoke("Button1",0.1f);
                }

                // Rotation basée sur le mouvement de la souris dans la direction horizontale
                float mouseX = Input.GetAxis("Mouse X");
                transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
            }
            else
            {
                Invoke("Floating",3f);
            }
        }
    }

    private void Button1()
    {
        ButtonEnfonce1 = true;
    }
    private void Button2()
    {
        ButtonEnfonce2 = true;
    }
    private void Button3()
    {
        ButtonEnfonce3 = true;
    }
    private void Button4()
    {
        ButtonEnfonce4 = true;
    }

    private void Floating()
    {
        transform.Translate(Vector3.up * vitesseDeplacement * Time.deltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        // Assurez-vous que 'other' n'est pas null avant d'y accéder
        if (other != null)
        {
            // Vérifiez si l'objet en collision a le tag spécifié
            if (other.CompareTag("Wheat"))
            {
                if(previousButton == "Left")
                {
                    transform.Translate(Vector3.right * 8);
                }
                if(previousButton == "Right")
                {
                    transform.Translate(Vector3.left * 8);
                }
                else
                {
                    transform.Translate(Vector3.back * 8);
                }
                
            }

            if (other.CompareTag("Box"))
            {
                if(countdown.DurationTime > 5f)
                {
                    IsPausedGame = true;
                    Lose.SetActive(true);
                    countdown.DurationTime += Time.deltaTime;
                    int durationTimeInt = Mathf.RoundToInt(countdown.DurationTime);
                    TimeSaved = durationTimeInt;
                    Score.text = "Score : " + TimeSaved.ToString();

                }
                
                
            }

        }
    }
}
