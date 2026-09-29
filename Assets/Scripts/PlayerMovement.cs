using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical");    

        Vector3 direction = new Vector3(x, y, 0f).normalized;
        transform.position += direction * _speed * Time.deltaTime;
    }
}