using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
 public bool IsKnockedDown = false;
    public bool isCounted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsKnockedDown)
        {
           
            return;
           
        }
        float angle = Vector3.Angle(transform.up, Vector3.up);
       if (angle > 30)
        {
            IsKnockedDown=true;
        }
    }
}
