using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Um desses deve ser criado para cada c�lula
public class CellObject
{
    private GridSystem _gridSystem; 
    private CellPosition _cellPosition; // Posi��o da c�lula em que o CellObject est�

    public CellObject(GridSystem gridSystem, CellPosition cellPosition)
    {
        _gridSystem = gridSystem;
        _cellPosition = cellPosition;
    }

    public override string ToString()
    {
        return $"x: {_cellPosition.x}; z: {_cellPosition.z}; ";
    }
}
