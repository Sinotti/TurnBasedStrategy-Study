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

    private CellPosition _currentCellPosition;
    private CellPosition _newCellPosition;

    private Vector3 _targetPos;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _targetPos = transform.position;
    }
    private void Start()
    {
        // Passo a posição desta unidade para a função que retorna em qual célula ela está:
        _currentCellPosition = LevelGrid.Instance.GetCellGridPos(transform.position); // (A própria unidade envia para o LevelGrid onde está)
        // Em seguida passo a posição da célula no grid que essa unidade está para a função
        // atribuí a mesma dentro do CellObject 
        LevelGrid.Instance.AddUnitAtCellPosition(_currentCellPosition, this);
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

        ChangeCellInGrid();
    }

    public void MoveUnit(Vector3 targetPos) 
    {
        _targetPos = targetPos;
    }

    private void PlayerRotation() 
    {
        transform.forward = Vector3.Lerp(transform.forward, _moveDirection, Time.deltaTime * _rotationSpeed);
    }

    public void ChangeCellInGrid() 
    {
        _newCellPosition = LevelGrid.Instance.GetCellGridPos(transform.position);

        if (_newCellPosition != _currentCellPosition)
        {
            // Move a unidade de posição da célula no LevelGrid
            LevelGrid.Instance.UnitMovedCellPosition(this, _currentCellPosition, _newCellPosition);
            _currentCellPosition = _newCellPosition; // Depois atualiza a posição da célula na própria unidade
        }
    }
}
