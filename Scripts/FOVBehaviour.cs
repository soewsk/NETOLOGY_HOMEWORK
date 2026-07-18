using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FOVBehaviour : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 fov;
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + fov, radius);
    }
}
