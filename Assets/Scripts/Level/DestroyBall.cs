using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameLogic.Instance.GameState = GameStates.GameState.PlayerDied;
            collision.gameObject.GetComponent<Ball>().DestroyObject();
        }
    }
}
