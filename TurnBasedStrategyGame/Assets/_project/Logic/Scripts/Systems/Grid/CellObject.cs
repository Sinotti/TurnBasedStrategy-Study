using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Um desses deve ser criado para cada célula
public class CellObject
{
    private GridSystem _gridSystem; 
    private CellPosition _cellPosition; // Posição da célula em que o CellObject está
    private List <Unit> _currentUnitsList;

    public CellObject(GridSystem gridSystem, CellPosition cellPosition)
    {
        _gridSystem = gridSystem;
        _cellPosition = cellPosition;

        _currentUnitsList = new List<Unit>();
    }

    public override string ToString()
    {
        string unitString = "";

        foreach(Unit unit in _currentUnitsList) 
        {
            unitString += unit + "\n";
        }

        return _cellPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Unit unit) 
    {
        _currentUnitsList.Add(unit);
    }

    public void RemoveUnit(Unit unit) 
    {
        _currentUnitsList.Remove(unit);
    }

    public List<Unit> GetUnitList() 
    {
        return _currentUnitsList;
    }
}
