
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GlobalStorage
{
    public static GlobalStorage Instance { get; private set; }


    public int highScore;
    public int health;
    public int collisions;
    public int collectedCoins;

    private string savePath;

    public GlobalStorage()
    {
        if (Instance == null)
        {
            Instance = this;
            savePath = Path.Combine(Application.persistentDataPath, "global_data.json");
            LoadData();
        }
    }

    public void SaveData()
    {

        GlobalData data = new GlobalData
        {
            highScore = highScore,
            health = health,
            collisions = collisions,
            collectedCoins = collectedCoins
        };


        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(savePath, json);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {

            string json = File.ReadAllText(savePath);
            GlobalData data = JsonConvert.DeserializeObject<GlobalData>(json);


            highScore = data.highScore;
            health = data.health;
            collisions = data.collisions;
            collectedCoins = data.collectedCoins;
        }
    }
}


[System.Serializable]
public class GlobalData
{
    public int highScore;
    public int health;
    public int collisions;
    public int collectedCoins;
}
