using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIdentification : MonoBehaviour
{
    public static int CurrentLevel;
    public static int LevelsUnlocked = 1;
    public Button[] Levels;

    private void Start()
    {
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
    }



    
}
