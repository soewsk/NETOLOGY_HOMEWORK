using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovManager : MonoBehaviour
{
    public Transform playerTransform;
    public float radius;
    public Vector3 fovEnemy;
    public float viewAngle;
    public void OnDrawGizmos()
    {
        Vector3 leftDirection;
        Vector3 rightDirection;

        Vector3 leftPoint;

        Vector3 rightPoint;
        Gizmos.DrawWireSphere(transform.position, radius);
       fovEnemy =  transform.position + transform.forward * radius;
        leftDirection = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward;
    leftPoint = transform.position + leftDirection * radius;
        rightDirection = Quaternion.Euler(0, viewAngle/2, 0) * transform.forward;
        rightPoint = transform.position + rightDirection * radius;
        Gizmos.DrawLine(transform.position, leftPoint);
        Gizmos.DrawLine(transform.position, rightPoint);
    
    }
    
    void Update()
    {
       float distance = Vector3.Distance(playerTransform.position, transform.position);
       
        if(distance < radius)
        {
            Vector3 playerDiretion = playerTransform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, playerDiretion);
           if(angle < viewAngle / 2)
            {
                Debug.Log("Враг обнаружен, дистанция до него:" + distance);
            }
         
        }

    }
}
