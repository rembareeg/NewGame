using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameStates;

public class GameLogic : Singleton<GameLogic>
{
    // Prevent non-singleton constructor use.
    protected GameLogic() { }

    private static bool _canDraw;

    private Camera _gameCamera;

    private Level _currentLevel;

    public static bool CanDraw    
    {
        get
        {
            return _canDraw;
        }
    }

    private float time = 0.0f;
    public GameState GameState;
    private SpawnObject[] BallsToSpawn;
    public event Action SpawnObject = delegate { };
    public event Action DestroyGameObject = delegate { };
    public event Action EnableMenuScreen = delegate { };
    public event Action<int> EnableEndScreen = delegate { };

    private void Awake()
    {
        GameState = GameState.Menu;
        
    }

    private void Start()
    {
        
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level != 0)
        {
            BallsToSpawn = FindObjectsOfType<SpawnObject>();
            GameState = GameState.Paused;
            _gameCamera = Camera.main;
        }
        
    }

    private async void FixedUpdate()
    {
        switch (GameState)
        {
            case GameState.Paused:
                _gameCamera.backgroundColor = Color.gray;
                _canDraw = true;
                EnableMenuScreen();
                DestroyGameObject();                
            break;

            case GameState.Spawning:
                time = 0.0f;
                _gameCamera.backgroundColor = Color.white;
                _canDraw = false;
                DestroyGameObject();
                SpawnObject();
                GameState = GameState.Playing;
            break;

            case GameState.Playing:
                time += Time.fixedDeltaTime;
                if (DestroyGameObject.GetInvocationList().Length  == 1)
                {
                    int stars;
                    if (time < _currentLevel.Time3)
                    {
                        EnableEndScreen(stars = 1);
                        if (time < _currentLevel.Time2)
                        {
                            EnableEndScreen(stars = 2);
                            if (time < _currentLevel.Time1)
                            {
                                EnableEndScreen(stars = 3);
                            }
                        }                   
                    }                    
                    else
                    {
                        EnableEndScreen(stars = 0);
                    }

                    PlayerPrefs.SetString(_currentLevel.SceneName + "Stars", stars.ToString());
                    GameState = GameState.Win;
                }
                break;

            case GameState.Win:

                break;
            case GameState.Menu:

                break;
            case GameState.PlayerDied:
                await Task.Delay(TimeSpan.FromSeconds(1));
                GameState = GameState.Paused;
                break;
        }        
        
    }

    public void SetCurrentLevel(Level currentLevel)
    {
        _currentLevel = currentLevel;
    }

}

