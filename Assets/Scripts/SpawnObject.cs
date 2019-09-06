using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Colors;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private float _force;
    [SerializeField]
    private ForceDirection _direction;
    [SerializeField]
    private GameColor _color;
    [SerializeField]
    private Material _redMaterial, _orangeMaterial, _greenMaterial, _blueMaterial, _purpleMaterial;
    [SerializeField]
    private Color _selectedColor;
    private Color _lightColor;
    private ParticleSystem.MinMaxGradient _gradient;
    public GameColor ObjectColor
    {       
        get
        {
            return _color;
        }
    }

    private void Awake()
    {
        GameLogic.Instance.SpawnObject += Spawn;
        ChangeColor(_color);
    }

    private void OnDestroy()
    {
        GameLogic.Instance.SpawnObject -= Spawn;
    }

    private void Spawn()
    {
        
        GameObject go = Instantiate(_object, transform.position, transform.rotation);
        go.GetComponent<SpriteRenderer>().color = _selectedColor;
        //go.GetComponent<TrailRenderer>().startColor = _selectedColor;

        //ParticleSystem.MainModule ps = go.GetComponent<ParticleSystem>().main;
        //ps.startColor = _gradient;
        go.GetComponent<TrailRenderer>().endColor = _lightColor;
        go.GetComponent<Ball>().SetColor(_color, _gradient);
        go.GetComponent<Rigidbody2D>().AddForce(_direction.Direction() * _force, ForceMode2D.Impulse);
    }

    private void OnValidate()
    {
        ChangeColor(_color);
    }
    private void ChangeColor(GameColor color)
    {
        
        switch(color)
        {
            case GameColor.Red:
                _selectedColor = _redMaterial.GetColor("Color_E9C8B141");
                transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = _redMaterial;
                break;
            case GameColor.Orange:
                _selectedColor = _orangeMaterial.GetColor("Color_E9C8B141");
                transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = _orangeMaterial;
                break;
            case GameColor.Green:
                _selectedColor = _greenMaterial.GetColor("Color_E9C8B141");
                transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = _greenMaterial;
                break;
            case GameColor.Blue:
                _selectedColor = _blueMaterial.GetColor("Color_E9C8B141");
                transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = _blueMaterial;
                break;
            case GameColor.Purple:
                _selectedColor = _purpleMaterial.GetColor("Color_E9C8B141"); 
                transform.GetChild(1).GetComponent<Renderer>().sharedMaterial = _purpleMaterial;
                break;
        }

        _lightColor = new Color(_selectedColor.r, _selectedColor.g, _selectedColor.b, 0.45f);
        _gradient = new ParticleSystem.MinMaxGradient(_selectedColor, _lightColor);
        _gradient.mode = ParticleSystemGradientMode.TwoColors;

        transform.GetChild(1).GetComponent<BallExit>().SetColor(_color);


    }

}
