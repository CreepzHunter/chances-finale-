using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject button;

    public int totalBoxes = 4;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        GenerateButtons();
    }

    public void GenerateButtons()
    {
        foreach (Transform child in puzzleField)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < totalBoxes; i++)
        {
            GameObject _button = Instantiate(button);
            _button.name = "" + i;
            _button.transform.SetParent(puzzleField, false);

            gameManager.RegisterButton(_button.GetComponent<Button>());

        }

    }

    public void ReplayGame()
    {
        gameManager.ResetGame();

        GenerateButtons();
        foreach (Transform child in puzzleField)
        {
            child.gameObject.SetActive(true);
        }
    }
}
