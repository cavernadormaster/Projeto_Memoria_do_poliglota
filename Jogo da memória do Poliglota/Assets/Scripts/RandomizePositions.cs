using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePositions : MonoBehaviour
{
    [SerializeField]
    private Transform Puzzefield;

    [SerializeField]
    private GameObject ButtonPuzzle;

    public int AmountOfNumbers;

    private void Awake()
    {
        for(int i =0; i < AmountOfNumbers * 4; i++)
        {
            GameObject button = Instantiate(ButtonPuzzle);
            button.name = "" + i;
            button.transform.SetParent(Puzzefield, false);
        }
    }

}
