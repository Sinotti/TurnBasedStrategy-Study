using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; } // A unidade vai precisar acessar a cell ap�s passar por ela

    [SerializeField] private GameObject _debugObjects;
    private GridSystem _gridSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(" There can only be one instance of UnitActionSystem.");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _gridSystem = new GridSystem(10, 10, 2);
        _gridSystem.CreateDebugCellObjects(_debugObjects);
    }

    public void AddUnitAtCellPosition(CellPosition cellPosition, Unit unit) 
    {
        CellObject currentCellObject = _gridSystem.GetCellObject(cellPosition);
        currentCellObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtCellPosition(CellPosition cellPosition) 
    {
        CellObject currentCellObject = _gridSystem.GetCellObject(cellPosition);

        return currentCellObject.GetUnitList();
    }

    public void RemoveUnitAtCellPosition(CellPosition cellPosition, Unit unitToRemove) 
    {
        CellObject currentCellObject = _gridSystem.GetCellObject(cellPosition);
        currentCellObject.RemoveUnit(unitToRemove);
    }

    public void UnitMovedCellPosition(Unit unit, CellPosition fromCellPosition, CellPosition toCellPosition) 
    {
        RemoveUnitAtCellPosition(fromCellPosition, unit);

        AddUnitAtCellPosition(toCellPosition, unit);
    }

    // Essa � uma forma de expor atrav�s dessa classe (nesse caso um singleton) apenas a fun��o desejada 
    // de outra classe, nesse exemplo GetCellGridPos presente em _gridSystem. Isso evita ter que fazer mais
    // uma referencia da classe GridSystem e ou expor essa classe inteira. Assim � exposto s� o necess�rio.
    public CellPosition GetCellGridPos(Vector3 worldPosition) => _gridSystem.GetCellGridPos(worldPosition); 
}
