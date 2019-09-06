using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDirection : MonoBehaviour
{
    [SerializeField]
    private Transform _endPoint;

    void OnDrawGizmosSelected()
    {
        if (_endPoint != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, _endPoint.position);
        }
    }

    public Vector2 Direction()
    {
        return _endPoint.position - transform.position;
    }
}
