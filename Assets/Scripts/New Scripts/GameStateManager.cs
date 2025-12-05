using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStateType
{
    Menu,
    Playing,
    GameOver
}

public interface IGameState
{
    void Enter();
    void Exit();
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public GameStateType InitialState = GameStateType.Playing;

    private IGameState currentState;
    private GameStateType currentStateType;

    [Header("UI (ถ้ามี)")]
    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject gameOverUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOverEvent;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOverEvent;
    }

    private void Start()
    {
        ChangeState(InitialState);
    }

    private void OnGameOverEvent()
    {
        ChangeState(GameStateType.GameOver);
    }

    public void ChangeState(GameStateType newStateType)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentStateType = newStateType;
        currentState = CreateState(newStateType);

        if (currentState != null)
        {
            currentState.Enter();
        }

        Debug.Log("GameState changed to: " + newStateType);
    }

    private IGameState CreateState(GameStateType type)
    {
        switch (type)
        {
            case GameStateType.Menu:
                return new MenuState(this);
            case GameStateType.Playing:
                return new PlayingState(this);
            case GameStateType.GameOver:
                return new GameOverState(this);
            default:
                return null;
        }
    }

    // -------------------------
    // Concrete States
    // -------------------------

    private class MenuState : IGameState
    {
        private readonly GameStateManager manager;

        public MenuState(GameStateManager manager)
        {
            this.manager = manager;
        }

        public void Enter()
        {
            if (manager.menuUI != null) manager.menuUI.SetActive(true);
            if (manager.gameplayUI != null) manager.gameplayUI.SetActive(false);
            if (manager.gameOverUI != null) manager.gameOverUI.SetActive(false);

            Time.timeScale = 0f;
        }

        public void Exit()
        {
            if (manager.menuUI != null) manager.menuUI.SetActive(false);
        }
    }

    private class PlayingState : IGameState
    {
        private readonly GameStateManager manager;

        public PlayingState(GameStateManager manager)
        {
            this.manager = manager;
        }

        public void Enter()
        {
            if (manager.gameplayUI != null) manager.gameplayUI.SetActive(true);
            if (manager.menuUI != null) manager.menuUI.SetActive(false);
            if (manager.gameOverUI != null) manager.gameOverUI.SetActive(false);

            Time.timeScale = 1f;
        }

        public void Exit()
        {
            // ยังไม่ต้องทำอะไรเพิ่ม
        }
    }

    private class GameOverState : IGameState
    {
        private readonly GameStateManager manager;

        public GameOverState(GameStateManager manager)
        {
            this.manager = manager;
        }

        public void Enter()
        {
            if (manager.gameOverUI != null) manager.gameOverUI.SetActive(true);
            if (manager.gameplayUI != null) manager.gameplayUI.SetActive(false);

            Time.timeScale = 0f;
        }

        public void Exit()
        {
            // ยังไม่ต้องทำอะไรเพิ่ม
        }
    }
}