using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public static int colluns;

    public GridLayoutGroup layoutGroup;

    public static int Level;

    public AudioSource audioSource;
    public AudioClip[] Audios;

    private void Awake()
    {
        layoutGroup.constraintCount = colluns;

        switch(LevelIdentification.CurrentLevel + 1)
        {
            case 1:
                Debug.Log("Fase 1");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Facil_Numeros_0A5");
                break;
            case 2:
                Debug.Log("Fase 2");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Facil_Numeros_0A5");
                break;
            case 3:
                Debug.Log("Fase 3");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Facil_Numeros_0A5");
                break;
            case 4:
                Debug.Log("Fase 4");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Medio_Numero_0A5");
                break;
            case 5:
                Debug.Log("Fase 5");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Medio_Numero_0A5");
                break;
            case 6:
                puzzles = Resources.LoadAll<Sprite>("Imagens/Medio_Numero_0A5");
                break;
            case 7:
                Debug.Log("Fase 7");
                puzzles = Resources.LoadAll<Sprite>("Imagens/Dificil_Numeros_0A5");
                break;
            case 8:
                puzzles = Resources.LoadAll<Sprite>("Imagens/Dificil_Numeros_0A5");
                break;
            case 9:
                puzzles = Resources.LoadAll<Sprite>("Imagens/Dificil_Numeros_0A5");
                break;
            case 10:
                puzzles = Resources.LoadAll<Sprite>("Imagens/Dificil_Numeros_0A5");
                break;
        
        }
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

            switch (gamePuzzles[firstGuessIndex].name)
            {
                case "Chinês - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[0]);
                    break;
                case "Inglês - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[1]);
                    break;
                case "Outro - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[2]);
                    break;
                case "Português - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[3]);
                    break;
                case "Chinês - 1_0":
                    audioSource.PlayOneShot(Audios[4]);
                    break;
                case "Inglês - 1_0":
                    audioSource.PlayOneShot(Audios[5]);
                    break;
                case "Outro - 1_0":
                    audioSource.PlayOneShot(Audios[6]);
                    break;
                case "Português - 1_0":
                    audioSource.PlayOneShot(Audios[7]);
                    break;
                case "2 - Chines_0":
                    audioSource.PlayOneShot(Audios[8]);
                    break;
                case "2 - Ingles_0":
                    audioSource.PlayOneShot(Audios[9]);
                    break;
                case "2 - outro_0":
                    audioSource.PlayOneShot(Audios[10]);
                    break;
                case "2 - Portugues_0":
                    audioSource.PlayOneShot(Audios[11]);
                    break;
                case "3 - chines_0":
                    audioSource.PlayOneShot(Audios[12]);
                    break;
                case "3 - ingles_0":
                    audioSource.PlayOneShot(Audios[13]);
                    break;
                case "3 - outro_0":
                    audioSource.PlayOneShot(Audios[14]);
                    break;
                case "3 - Portugues_0":
                    audioSource.PlayOneShot(Audios[15]);
                    break;
                case "4 - chines_0":
                    audioSource.PlayOneShot(Audios[16]);
                    break;
                case "4 - ingles_0":
                    audioSource.PlayOneShot(Audios[17]);
                    break;
                case "4 - outro_0":
                    audioSource.PlayOneShot(Audios[18]);
                    break;
                case "4 - portugues_0":
                    audioSource.PlayOneShot(Audios[19]);
                    break;
                case "5 - chines_0":
                    audioSource.PlayOneShot(Audios[20]);
                    break;
                case "5 - ingles_0":
                    audioSource.PlayOneShot(Audios[21]);
                    break;
                case "5 - outro_0":
                    audioSource.PlayOneShot(Audios[22]);
                    break;
                case "5 - portugues_0":
                    audioSource.PlayOneShot(Audios[23]);
                    break;

            }


            buttons[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            SecondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            switch (gamePuzzles[secondGuessIndex].name)
            {
                case "Chinês - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[0]);
                    break;
                case "Inglês - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[1]);
                    break;
                case "Outro - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[2]);
                    break;
                case "Português - 0_0":
                    Debug.Log("Tocou");
                    audioSource.PlayOneShot(Audios[3]);
                    break;
                case "Chinês - 1_0":
                    audioSource.PlayOneShot(Audios[4]);
                    break;
                case "Inglês - 1_0":
                    audioSource.PlayOneShot(Audios[5]);
                    break;
                case "Outro - 1_0":
                    audioSource.PlayOneShot(Audios[6]);
                    break;
                case "Português - 1_0":
                    audioSource.PlayOneShot(Audios[7]);
                    break;
                case "2 - Chines_0":
                    audioSource.PlayOneShot(Audios[8]);
                    break;
                case "2 - Ingles_0":
                    audioSource.PlayOneShot(Audios[9]);
                    break;
                case "2 - outro_0":
                    audioSource.PlayOneShot(Audios[10]);
                    break;
                case "2 - Portugues_0":
                    audioSource.PlayOneShot(Audios[11]);
                    break;
                case "3 - chines_0":
                    audioSource.PlayOneShot(Audios[12]);
                    break;
                case "3 - ingles_0":
                    audioSource.PlayOneShot(Audios[13]);
                    break;
                case "3 - outro_0":
                    audioSource.PlayOneShot(Audios[14]);
                    break;
                case "3 - Portugues_0":
                    audioSource.PlayOneShot(Audios[15]);
                    break;
                case "4 - chines_0":
                    audioSource.PlayOneShot(Audios[16]);
                    break;
                case "4 - ingles_0":
                    audioSource.PlayOneShot(Audios[17]);
                    break;
                case "4 - outro_0":
                    audioSource.PlayOneShot(Audios[18]);
                    break;
                case "4 - portugues_0":
                    audioSource.PlayOneShot(Audios[19]);
                    break;
                case "5 - chines_0":
                    audioSource.PlayOneShot(Audios[20]);
                    break;
                case "5 - ingles_0":
                    audioSource.PlayOneShot(Audios[21]);
                    break;
                case "5 - outro_0":
                    audioSource.PlayOneShot(Audios[22]);
                    break;
                case "5 - portugues_0":
                    audioSource.PlayOneShot(Audios[23]);
                    break;

            }

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
            if (Level == LevelIdentification.CurrentLevel + 1)
            {
                LevelIdentification.CurrentLevel++;
                LevelIdentification.LevelsUnlocked++;
                SaveGameSystem.LevelsUnlokcked = LevelIdentification.LevelsUnlocked;
                SceneManager.LoadScene("FinalizationScene");
            }
            else
            {
                SaveGameSystem.LevelsUnlokcked = LevelIdentification.LevelsUnlocked;
                SceneManager.LoadScene("FinalizationScene");
            }
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
