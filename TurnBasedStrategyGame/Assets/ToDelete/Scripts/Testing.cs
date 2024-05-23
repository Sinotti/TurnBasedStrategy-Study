using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private GameObject _cellObjectDebug;
    
    private GridSystem _gridSystem;

    private void Start()
    {
        _gridSystem = new GridSystem(10, 10, 2f);
        _gridSystem.CreateDebugCellObjects(_cellObjectDebug);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CellPosition currentCellPosition = _gridSystem.GetCellGridPos(MouseWorld.GetMousePosition());
            Vector3 currentCellWorldPosition = _gridSystem.GetCellWorldPos(currentCellPosition);

            Debug.Log("Posição da Celula no Grid: " + currentCellPosition);
            Debug.Log("Posição da Célula no Mundo: " + currentCellWorldPosition);
        }
        
    }
}
