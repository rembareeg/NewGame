using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStates;

public class GameLogic : Singleton<GameLogic>
{
    // Prevent non-singleton constructor use.
    protected GameLogic() { }

    public event Action SpawnObject = delegate { };
    public event Action DestroyGameObject = delegate { };

    public GameState GameState;
    
    // Then add whatever code to the class you need as you normally would.
    public string MyTestString = "Hello world!";

    private void Awake()
    {
        GameState = GameState.Paused;
        
    }

    private void Update()
    {
        

        switch (GameState)
        {
            case GameState.Paused:
                DestroyGameObject();
            break;

            case GameState.Spawning:
                SpawnObject();
                GameState = GameState.Playing;

            break;

            case GameState.Playing:
                

            break;
        }


        
        
    }


}

