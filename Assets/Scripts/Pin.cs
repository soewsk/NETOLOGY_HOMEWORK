using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
 public bool IsKnockedDown = false;
    public bool isCounted = false;
    private Rigidbody _rb;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    public void ResetPin()
    {
        IsKnockedDown=false;
        isCounted=false;
        transform.position=StartPosition;
        transform.rotation=StartRotation;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartPosition = transform.position;
        StartRotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsKnockedDown)
        {
           gameObject.SetActive(false);
            return;
           
        }
        float angle = Vector3.Angle(transform.up, Vector3.up);
       if (angle > 60)
        {
            IsKnockedDown=true;
        }
    }
}
