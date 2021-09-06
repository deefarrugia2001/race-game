using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] AudioClip pointsSoundEffect;
    GameSession gameSession;
    int points = 5;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 10) 
        {
            AudioSource.PlayClipAtPoint(pointsSoundEffect, Camera.main.transform.position);
            Destroy(collision.gameObject);
            gameSession.AddToScore(points);
        }
        else 
        {
            Debug.Log("You have dodged a bullet.");
        }
    }
}