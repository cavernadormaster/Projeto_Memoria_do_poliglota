using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToChange;

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
   
}
