using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Um desses deve ser criado para cada célula
public class CellObject
{
    private GridSystem _gridSystem; 
    private CellPosition _cellPosition; // Posição da célula em que o CellObject está

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
