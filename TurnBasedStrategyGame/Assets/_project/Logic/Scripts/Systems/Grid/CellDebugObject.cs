using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CellDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    
    private CellObject _cellObject;

    public void SetCellObjectValue(CellObject cellObject) 
    {
        _cellObject = cellObject;

        _textMeshPro.text = _cellObject.ToString();
    }
}
