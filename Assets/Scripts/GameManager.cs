using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Time.timeScale = 0;
        GameStateManager.onGameOver += OnGameOver;
        GameStateManager.onPause += OnPause;
        GameStateManager.onInGame += OnInGame;
        
        DontDestroyOnLoad(gameObject);
    }
    
    private void OnPause()
    {
        Time.timeScale = 0;
        
        SceneNeededAction.pauseMenu.SetActive(true);
    }

    private void OnInGame()
    {
        Time.timeScale = 1;
        
        SceneNeededAction.mainMenu.SetActive(false);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
