using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIdentification : MonoBehaviour
{
    public static int CurrentLevel;
    public static int LevelsUnlocked = 0;
    public Button[] Levels;
    public static Button[] LevelsReset;
    public static bool jaPassouDoTitulo;
    public static int TipodeNivel;

    private void Start()
    {
        LevelsReset = Levels;

        if(GameObject.FindGameObjectsWithTag("LevelController")== null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    private void Update()
    {
        for(int i = 0; i < LevelsUnlocked; i++)
        {
            Levels[i].interactable = true;
            Debug.Log(LevelsUnlocked);
            Debug.Log(CurrentLevel);
        }
        Levels[CurrentLevel].interactable = true;

        if(CurrentLevel + 1 == 10)
        {
            Button resetButton = GameObject.FindGameObjectWithTag("ResetButton").GetComponent<Button>();
            resetButton.interactable = true;
        }
    }

    public static void ResetLevels()
    {
        for (int i = 0; i < 10; i++)
        {
            LevelsReset[i].interactable = false;
        }
        
    }


    
}
