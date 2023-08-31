using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonScript : MonoBehaviour
{
    public Button button;
    private GameManager gameManager;
    private int _difficultyIndex;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked.");
        if(gameObject.name == "Easy")
        {
            _difficultyIndex = 1;
        }
        else if (gameObject.name == "Medium")
        {
            _difficultyIndex = 2;
        }
        else if (gameObject.name == "Hard")
        {
            _difficultyIndex = 3;
        }
        gameManager.StartGame(_difficultyIndex);

    }
}
