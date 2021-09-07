using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float waitDelay = 2f;
    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();    
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadWin() 
    {
        SceneManager.LoadScene("Win");
    }

    public void LoadLose() 
    {
        StartCoroutine(LoadAfterDelay("Lose"));
    }

    IEnumerator LoadAfterDelay(string scene) 
    {
        yield return new WaitForSeconds(waitDelay);
        SceneManager.LoadScene(scene);
    }
}