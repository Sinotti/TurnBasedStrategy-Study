using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;

    [SerializeField] private LayerMask _mouseLayerMask;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.position = MouseWorld.GetClickedPosition();
    }

    public static Vector3 GetClickedPosition() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance._mouseLayerMask);
        return raycastHit.point;
    }
}
