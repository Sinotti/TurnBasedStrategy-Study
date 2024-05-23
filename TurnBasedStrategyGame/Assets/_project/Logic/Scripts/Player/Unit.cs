using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Movement Parameters")]
    [Space(6)]
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private float _stoppingDistance = .1f;

    [Header("References")]
    [Space(6)]
    [SerializeField] private Animator _anim;

    private Vector3 _targetPos;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _targetPos = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPos) > _stoppingDistance)
        {
            _moveDirection = (_targetPos - transform.position).normalized;
            transform.position += _moveDirection * _moveSpeed * Time.deltaTime;

            PlayerRotation();

            _anim.SetBool("IsWalking", true);
        }
        else 
        {
            _anim.SetBool("IsWalking", false);
        }
    }

    public void Move(Vector3 targetPos) 
    {
        _targetPos = targetPos;
    }

    private void PlayerRotation() 
    {
        transform.forward = Vector3.Lerp(transform.forward, _moveDirection, Time.deltaTime * _rotationSpeed);
    }
}
