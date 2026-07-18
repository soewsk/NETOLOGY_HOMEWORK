using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform throwPoint;
    [SerializeField] float throwForce;
 private bool isBallThrown = false;
    public GameManager gameManager;

   
    RaycastHit hit;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    transform.position = throwPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0) && !isBallThrown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 direction = hit.point - transform.position;
                isBallThrown = true;
                direction.y = 0f;
                rb.AddForce(direction.normalized * throwForce, ForceMode.Impulse);
                StartCoroutine(DeleateTheBall());
            }
        }
        
    }

    IEnumerator DeleateTheBall()
    {
        yield return new WaitForSeconds(6f);
        gameManager.CalculateScore();
        transform.position = throwPoint.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isBallThrown = false;
    }

    

}
