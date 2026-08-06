using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    public AudioSource _playerSound;
  
    void Update()
    {
        bool playerMovement = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime);
        playerMovement = true;
        } 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * _speed * Time.deltaTime);
            playerMovement = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * _speed * Time.deltaTime);
            playerMovement = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * _speed * Time.deltaTime);
            playerMovement = true;
        }
        if(playerMovement)
        {
            if(_playerSound.isPlaying == false)
            {
                _playerSound.Play();
            }
        }
        else
        {
            _playerSound.Stop();
        }
    }
}
