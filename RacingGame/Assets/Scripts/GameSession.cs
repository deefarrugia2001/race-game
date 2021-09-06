using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    static List<GameSession> sessionInstances;
    int score = 0;

    public int Score => score;

    void Awake()
    {
        ImplementSingleton();
    }

    void ImplementSingleton() 
    {
        sessionInstances = FindObjectsOfType<GameSession>().ToList();
        if (sessionInstances.Count > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    public void AddToScore(int pointsToAdd) 
    {
        score += pointsToAdd;
    }

    public void ResetGame() 
    {
        Destroy(gameObject);
    }
}