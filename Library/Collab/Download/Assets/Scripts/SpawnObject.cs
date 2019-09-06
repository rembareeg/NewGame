using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private float _force;
    [SerializeField]
    private ForceDirection _direction;

    private void Awake()
    {
        GameLogic.Instance.SpawnObject += Spawn;
    }

    private void Spawn()
    {
        GameObject go = Instantiate(_object, transform.position, transform.rotation);

        go.GetComponent<Rigidbody2D>().AddForce(_direction.Direction() * _force, ForceMode2D.Impulse);
    }

}
