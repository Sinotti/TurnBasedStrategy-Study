using System;
using UnityEngine;
using UnityEngine.Events;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += OnSelectedUnitChanged;
    }

    private void OnSelectedUnitChanged(object sender, EventArgs empty) 
    {
        ToggleSelectionVisual(); 
    }

    private void ToggleSelectionVisual() 
    {
        // Se a unidade selecionada for igual a esta unidade.
        if (UnitActionSystem.Instance.GetSelectedUnit() == _unit)
        {
            _meshRenderer.enabled = true;
        }
        else
        {
            _meshRenderer.enabled = false;
        }
    }
}
