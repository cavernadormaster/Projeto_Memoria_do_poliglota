using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToChange;
    
    int Dificulti;

    public GameObject[] TiposDeNivel;
    public GameObject Titulo;
    

    private void Start()
    {
        if (LevelIdentification.jaPassouDoTitulo)
        {
            Debug.Log("Japassei");
            Titulo.SetActive(false);
        }
    }

    private void Update()
    {
        switch(LevelIdentification.TipodeNivel)
        {
            case 0:
                return;
            case 1:
                TiposDeNivel[0].SetActive(true);
                break;
            case 2:
                TiposDeNivel[1].SetActive(true);
                break;
        }
    }

   

    public void SetTypeOfLevel(int Type)
    {
       LevelIdentification.TipodeNivel = Type;
        LevelIdentification.jaPassouDoTitulo = true;
    }

    public void Changescene()
    {
        SaveGameSystem.SavingGame = true;
        SceneManager.LoadScene(SceneToChange);
    }

    public void ExitGame()
    {
        SaveGameSystem.SavingGame = true;
        Application.Quit();
    }

    public void SetAmoutOfNumbers(int level)
    {
        RandomizePositions.AmountOfNumbers = level;
    }

    public void SetCollunsNumber(int colluns)
    {
        GameController.colluns = colluns;
    }

    public void LoadGame()
    {
        SaveGameSystem.LoadingData = true;
    }

    public static void Level(int Level)
    {
        GameController.Level = Level;
    }

    public void DeleteSavedGames()
    {
        SaveGameSystem.DeleteData();
        LevelIdentification.LevelsUnlocked = 0;
        LevelIdentification.CurrentLevel = 0;
        LevelIdentification.ResetLevels();
        SaveGameSystem.SaveData();
    }
   
}
