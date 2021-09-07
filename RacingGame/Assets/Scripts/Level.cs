using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    static List<Level> levelInstances;
    [SerializeField] float waitDelay = 2f;
    GameSession gameSession;

    void Awake()
    {
        ImplementSingleton();
    }

    void ImplementSingleton() 
    {
        levelInstances = FindObjectsOfType<Level>().ToList();
        if (levelInstances.Count > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

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

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}