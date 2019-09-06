using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody2D _ballPhysics;

    // Awake is called before start
    void Awake()
    {
        _ballPhysics = GetComponent<Rigidbody2D>();
        GameLogic.Instance.DestroyGameObject += DestroyObject;
    }

    private void DestroyObject()
    {
        GameLogic.Instance.DestroyGameObject -= DestroyObject;
        Destroy(this.gameObject);
    }

    
}
