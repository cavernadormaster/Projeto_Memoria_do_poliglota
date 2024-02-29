using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string SceneToChange;

    public void Changescene()
    {
        SceneManager.LoadScene(SceneToChange);
    }

    public void ExitGame()
    {
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

   
}
