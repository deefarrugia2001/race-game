using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreElement;
    GameSession gameSession;

    void Start()
    {
        scoreElement = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        scoreElement.text = gameSession.Score.ToString();
    }
}
