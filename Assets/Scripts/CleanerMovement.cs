using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CleanerMovement : MonoBehaviour
{
    public float _speed;
    private Rigidbody _rb;
    private bool CheckWallForward = false;
    private bool CheckWallRight = false;
    private bool CheckWallLeft = false;
    public float Distance;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Vector3 force = transform.forward * _speed;
        _rb.velocity = force;
        


    }


    public void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Distance))
        {
            if (!CheckWallForward)
            {
                float angle = Random.Range(60f, 110f);
                transform.rotation *= Quaternion.Euler(0, angle, 0);

                CheckWallForward = true;
           return;
            }
            else
            {
                CheckWallForward = false;
            }

        }

        if (Physics.Raycast(transform.position, transform.right, out hit, Distance))
        {
            if (!CheckWallRight)
            {
                float angle = Random.Range(-110f, -60f);
                transform.rotation *= Quaternion.Euler(0, angle, 0);
                CheckWallRight = true;
                return;
            }
            else
            {
                CheckWallRight = false;
            }
        
        }
        if(Physics.Raycast(transform.position, -transform.right, out hit, Distance))
        {
            if (!CheckWallLeft)
            {
                float angle = Random.Range(60f, 110f);
                transform.rotation *= Quaternion.Euler(0, angle, 0);
                CheckWallLeft = true;
                return ;
            }
            else
            {
                CheckWallLeft = false;
            }

        }
        
        

            Debug.DrawRay(ray.origin, ray.direction * Distance, Color.red);
        Debug.DrawRay(ray.origin, transform.right * Distance , Color.blue);
        Debug.DrawRay(ray.origin, -transform.right * Distance, Color.green);




    }
   

}
