using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyingsauce : MonoBehaviour
{
    public GameObject[] waypoints;
    public float vitesseDeplacement;
    private bool IsMoving;
    private int RandomValue;
    private float Position1;
    private float Position2;
    private float Position3;
    private float Position4;

    public GameObject redcircle;
    public GameObject DamageArea;
    private bool Createbool;
    private bool StopMoving;

    private int ValueBool;

    private float ShrinkingRadius;
    public CowMovement cowMovement;
    public SwitchScene switchScene;
    
    // Start is called before the first frame update
    void Start()
    {
        IsMoving = true;
        Position1 = transform.position.x;
        Position3 = transform.position.z;
        ShrinkingRadius = 2f;
        Createbool = true;
        ValueBool = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if(switchScene.GameStarted)
        {

            
            if(!cowMovement.IsPausedGame)
            {

                
                Position2 = Position1;
                Position4 = Position3;
                Position1 = transform.position.x;
                Position3 = transform.position.z;

                int random = Random.Range(0, waypoints.Length);
                if (IsMoving)
                {
                    RandomValue = random;

                    IsMoving = false;
                }

                
                Vector3 nouvellePosition = new Vector3(waypoints[RandomValue].transform.position.x, transform.position.y, waypoints[RandomValue].transform.position.z);
                MoveToPosition(nouvellePosition);


                if (Mathf.Approximately(Position1, Position2) && Mathf.Approximately(Position3, Position4))
                {
                    if (StopMoving == false && ValueBool == 2)
                    {
                        StopMoving = true;
                        Invoke("StopMove", 5f);
                    }

                    IsMoving = true;
                    
                }
                else
                {
                    ValueBool = 2;
                }

                if (Createbool == true && StopMoving == true)
                {
                    Createbool = false;
                    Invoke("CreateCircle", 1f);
                }

                GameObject damageArea = Instantiate(DamageArea, transform.position, transform.rotation);
                Vector3 damageAreaPosition = new Vector3(damageArea.transform.position.x, -3f, damageArea.transform.position.z);
                damageArea.transform.position = damageAreaPosition;
            }
        }

    }

    private void MoveToPosition(Vector3 destination)
    {
        if (StopMoving == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, vitesseDeplacement * Time.deltaTime);
        }

    }

    void CreateCircle()
    {
        GameObject redCircle = Instantiate(redcircle, transform.position, transform.rotation);
        Createbool = true;
    }

    void StopMove()
    {
        StopMoving = false;
        ValueBool = 1;
    }
}
