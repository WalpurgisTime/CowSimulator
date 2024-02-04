using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    [System.Serializable]
    public class CowData
    {
        public int _1;
        public int _2;
        public int _3;
        public int _4;
        public int _5;
        public int _6;
        public int _7;
        public int _8;
        public int _9;
        public int _10;
    }
    private CowData cowData;
    private bool IsChanged;
    private int previous;
    public Text LeaderBoard;
    public CowMovement cowMovement;
    public Button Clicked;
    
    

    // Appelé au démarrage
    void Start()
    {
        
    }

    public void InputLeader()
    {
        if(Clicked.interactable)
        {
            string inputValue = cowMovement.TimeSaved.ToString();

            // Vous pouvez utiliser la valeur comme vous le souhaitez, par exemple, convertir en int
            if (int.TryParse(inputValue, out int intValue))
            {
                IsChanged = false;
                LoadDataFromJson();
                LeaderBoard.text = "";
                ModifyAndSaveCowData(intValue);
            }

            
        }

    }




    // Appelé à chaque image
    void Update()
    {
        // Mettez le code de mise à jour ici si nécessaire
    }

    // Charge les données depuis un fichier JSON
    public void LoadDataFromJson()
    {
        string filePath = Application.persistentDataPath + "/CowData.json";

        if (System.IO.File.Exists(filePath))
        {
            string jsonText = System.IO.File.ReadAllText(filePath);

            // Utilisez "this.cowData" pour faire référence à la variable membre
            this.cowData = JsonUtility.FromJson<CowData>(jsonText);
        }
        else
        {
            Debug.LogError("Fichier JSON non trouvé");
        }
    }

    public void SaveDataToJson(CowData cowData)
    {
        string filePath = Application.persistentDataPath + "/CowData.json";

        string cowDataJson = JsonUtility.ToJson(cowData);
        System.IO.File.WriteAllText(filePath, cowDataJson);
    }

    void ModifyAndSaveCowData(int value)
    {
        LoadDataFromJson();

        for (int i = 1; i <= 10; i++)
        {
            // Utilisez la réflexion pour obtenir la valeur de la propriété en fonction du numéro (1 à 10)
            int currentValue = (int)this.cowData.GetType().GetField("_" + i).GetValue(this.cowData);
            
            
            if ( IsChanged == true)
            {
                this.cowData.GetType().GetField("_" + i).SetValue(this.cowData, previous);
                previous = currentValue;
            }
            
            // Vérifiez la condition et mettez à jour la valeur si nécessaire
            if (currentValue < value && IsChanged == false)
            {
                previous = currentValue;
                this.cowData.GetType().GetField("_" + i).SetValue(this.cowData, value);
                
                IsChanged = true;
                
            }

            int NewcurrentValue = (int)this.cowData.GetType().GetField("_" + i).GetValue(this.cowData);
            LeaderBoard.text += "\n Player  "+ i + ": " + NewcurrentValue;


           
        }

        SaveDataToJson(cowData);
    }



}
