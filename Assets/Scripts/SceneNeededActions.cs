using UnityEngine;

public class SceneNeededAction : MonoBehaviour
{
    //Ugly code but i'm way to late to even think about what i write
    public GameObject MainMenuParam;
    public GameObject PauseMenuParam;
    
    public static GameObject mainMenu;
    public static GameObject pauseMenu;

    void Start()
    {
        mainMenu = MainMenuParam;
        pauseMenu = PauseMenuParam;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        
        GameStateManager.SetState(GameState.InGame);
    }
}
