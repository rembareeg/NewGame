using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Colors;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _ballPhysics;
    [SerializeField]
    private GameObject _deathParticleObject;
    private ParticleSystem.MinMaxGradient _particleGradient;
    private GameColor _color;
    public GameColor ObjectColor
    {
        get
        {
            return _color;
        }
    }


    // Awake is called before start
    private void Awake()
    {
        _ballPhysics = GetComponent<Rigidbody2D>();
        GameLogic.Instance.DestroyGameObject += DestroyObject;
    }

    private void OnDestroy()
    {
        GameLogic.Instance.DestroyGameObject -= DestroyObject;
    }

    public void DestroyObject()
    {
        GameObject go = Instantiate(_deathParticleObject, transform.position, transform.rotation, transform.parent);
        ParticleSystem.MainModule ps = go.GetComponent<ParticleSystem>().main;
        ps.startColor = _particleGradient;
        go.GetComponent<ParticleSystem>().Play();
        Destroy(this.gameObject);
    }

    public void SetColor(GameColor color, ParticleSystem.MinMaxGradient gradient)
    {
        _particleGradient = gradient;
        
        _color = color;
    }
    
}
