using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip pointsSoundEffect;

    Level level;
    GameSession gameSession;
    int points = 5;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 10) 
        {
            AudioSource.PlayClipAtPoint(pointsSoundEffect, Camera.main.transform.position);
            Destroy(collision.gameObject);
            gameSession.AddToScore(points);

            if (gameSession.Score >= 100)
            {
                AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
                level.LoadWin();
            }
        }
    }
}