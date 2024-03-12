using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIdentification : MonoBehaviour
{
    public static int CurrentLevel;
    public static int LevelsUnlocked = 1;
    public Button[] Levels;
    public static Button[] LevelsReset;

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
        }
        Levels[CurrentLevel].interactable = true;

        if(CurrentLevel + 1 == 3)
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
