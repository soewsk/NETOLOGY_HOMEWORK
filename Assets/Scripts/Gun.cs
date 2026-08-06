using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource _fireSound;
    public AudioSource _hitSound;
    public AudioSource _reloadSound;
   

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            if(Physics.Raycast(ray, out hit))
            {
                Hit();
            }
        
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    
    }

    public void Fire()
    {
        _fireSound.Play();
    }
    public void Hit()
    {
        _hitSound.Play();
    }
    public void Reload()
    {
        _reloadSound.Play();
    }


}
