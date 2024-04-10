using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    void Start()
    {
        GlobalStorage globalStorage = GlobalStorage.Instance;
        int record = globalStorage.highScore;
        int healthCount = globalStorage.health;
        int collisionCount = globalStorage.collisions;
        int collectedCoins = globalStorage.collectedCoins;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnApplicationQuit()
    {
        GlobalStorage globalStorage = GlobalStorage.Instance;
        globalStorage.SaveData();
    }
}
