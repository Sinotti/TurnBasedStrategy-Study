using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro _cellPositionTMP;
    private CellObject _cellObject;

    private void Update()
    {
        RefreshDebugValues();
    }
    private void RefreshDebugValues() 
    {
        _cellPositionTMP.text = _cellObject.ToString();
    }
    public void SetDebugCellPos(CellObject cellObject) 
    {
        _cellObject = cellObject;
    }
}
