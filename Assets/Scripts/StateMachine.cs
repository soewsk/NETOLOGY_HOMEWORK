using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusForTarget;
    [SerializeField] private float _timer;

    private float _hitDistance = 0.3f;
    private AiState currentState;
    private enum AiState
    {
        EnemyIdleState,
        EnemyMovingState,
        EnemyAttackState

    }
    void Start()
    {
        currentState = AiState.EnemyIdleState;
        _hitDistance *= _hitDistance;
        _radiusForTarget *= _radiusForTarget;
    }
    void Update()
    {
        switch(currentState)
        {
            case AiState.EnemyIdleState:
                Idle();
                break;

            case AiState.EnemyMovingState:
                Moving();
                break;

            case AiState.EnemyAttackState:
                Attack();
                break;
        }
    }
    private void Idle()
    {
        if (Vector3.SqrMagnitude(_playerTransform.transform.position - transform.position) <= _radiusForTarget)
        {
            currentState = AiState.EnemyMovingState;
        }
    }

    private void Moving()
    {
        var direction = Vector3.Normalize(_playerTransform.transform.position - transform.position);
        direction *= _speed * Time.deltaTime;
        transform.position += direction;
        if (Vector3.SqrMagnitude(transform.position - _playerTransform.transform.position) <= _hitDistance)
        {
            currentState = AiState.EnemyAttackState;
        }
    }
    
    private void Attack()
    {
        _timer += Time.deltaTime;
        if (_timer > 1.5f)
        {
            Debug.Log("Hit!");
            _timer = 0;
        }
        if (Vector3.SqrMagnitude(transform.position - _playerTransform.transform.position) > _hitDistance)
        {
            
            _timer = 0;                      
            currentState = AiState.EnemyMovingState;           
        }
    }


}
