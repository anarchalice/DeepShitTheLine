using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public static bool isPaused { get; private set; }
    public static GameState currentState { get; private set; }
    public static event Action<GameState> onStateChange;
    public static Action onMenu, onInGame, onGameOver, onPause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SetState(GameState.Menu);
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetState(GameState newState)
    {
        isPaused = newState == GameState.Pause;
        currentState = newState;
        onStateChange?.Invoke(currentState);

        // Invoke the corresponding event
        switch (newState)
        {
            case GameState.Menu:
                onMenu?.Invoke();
                break;
            case GameState.InGame:
                onInGame?.Invoke();
                break;
            case GameState.GameOver:
                onGameOver?.Invoke();
                break;
            case GameState.Pause:
                onPause?.Invoke();
                break;
        }
    }
}

public enum GameState
{
    Menu,
    InGame,
    GameOver,
    Pause
}