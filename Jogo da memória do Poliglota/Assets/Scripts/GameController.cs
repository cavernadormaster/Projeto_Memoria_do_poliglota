using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> buttons = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses, countCorrectguesses, gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, SecondGuessPuzzle;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Imagens/Numbers");
    }

    private void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzzles()
    {
        int looper = buttons.Count;
        int index = 0;

        for (int i =0; i < looper; i++)
        {
            if(index == looper/2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button bnt in buttons)
        {
            bnt.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            buttons[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            SecondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            buttons[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());

        }
    }
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == SecondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);

            buttons[firstGuessIndex].interactable = false;
            buttons[secondGuessIndex].interactable = false;

            buttons[firstGuessIndex].image.color = new Color(0, 0, 0,0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            buttons[firstGuessIndex].image.sprite = bgImage;
            buttons[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectguesses++;

        if(countCorrectguesses == gameGuesses)
        {
            Debug.Log("Finished");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
