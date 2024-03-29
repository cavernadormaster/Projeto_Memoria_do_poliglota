using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveGameSystem : MonoBehaviour
{
    public static int LevelsUnlokcked;
    public static bool SavingGame;
    public static bool LoadingData;


    private void Update()
    {
        if(SavingGame)
        {
            SaveData();
            SavingGame = false;
        }

        if(LoadingData)
        {
            LoadData();
            LoadingData = false;
        }
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", LevelsUnlokcked);
    }

    public static void LoadData()
    {
        LevelIdentification.LevelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked");
    }

    public static void DeleteData()
    {
        PlayerPrefs.DeleteKey("LevelsUnlocked");
    }
}
