using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance {  get; private set; }

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit _currentUnit;
    [SerializeField] private LayerMask _unitLayerMask;

    // Lembrando que o return saí da função.
    // Refatorar Inputs para o New Input System.
    // Talvez refatorar os eventos.

    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.LogError(" There can only be one instance of UnitActionSystem.");
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Se selecionar uma unidade o resto (Move) não executa
            if (TryUnitSelect()) return;

            _currentUnit.Move(MouseWorld.GetMousePosition());
        }
    }

    private bool TryUnitSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _unitLayerMask)) 
        {
            if (raycastHit.transform.TryGetComponent(out Unit currentUnit)) 
            {
                SetSelectedUnit(currentUnit);
                return true; 
            }
        }

        return false;
    }

    private void SetSelectedUnit(Unit unit) 
    {
        _currentUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit() 
    {
        return _currentUnit;
    }
}
