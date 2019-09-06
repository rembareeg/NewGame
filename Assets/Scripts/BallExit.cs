using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Colors;

public class BallExit : MonoBehaviour
{
    private GameColor _color;
    public GameColor ObjectColor
    {
        get
        {
            return _color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (_color != collision.gameObject.GetComponent<Ball>().ObjectColor)
            {
                GameLogic.Instance.GameState = GameStates.GameState.PlayerDied;
            }
            collision.gameObject.GetComponent<Ball>().DestroyObject();
            
        }
    }

    public void SetColor(GameColor color)
    {
        _color = color;
    }
}
