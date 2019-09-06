using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStates;

public class GUI : MonoBehaviour
{
    public void Pause()
    {
        GameLogic.Instance.GameState = GameState.Paused;
    }

    public void Play()
    {
        GameLogic.Instance.GameState = GameState.Spawning;
    }
}
