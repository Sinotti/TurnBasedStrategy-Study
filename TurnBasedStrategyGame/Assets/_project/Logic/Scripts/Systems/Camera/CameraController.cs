using UnityEngine;
using Cinemachine;
using UnityEditor.ShaderGraph.Internal;

public class CameraController : MonoBehaviour
{
    [Header("Camera Parameters")]
    [Space(6)]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _zoomAmount;
    [SerializeField] private Vector3 _followOffset;

    [Header("References")]
    [Space(6)]
    [SerializeField] private CinemachineVirtualCamera _vCam;
    
    private const float MIN_FOLLOW_Y_OFFSET = 1f;
    private const float MAX_FOLLOW_Y_OFFSET = 12f;

    private CinemachineTransposer _cmTransposer;
    private Vector3 _inputMoveDir;
    private Vector3 _move;
    private Vector3 _rotation;
    private Vector3 _targetFollowOffset;

    private void Start()
    {
        _cmTransposer = _vCam.GetCinemachineComponent<CinemachineTransposer>();
        _targetFollowOffset = _cmTransposer.m_FollowOffset;
    }
    private void Update()
    {
        // Refatorar tudo

        _inputMoveDir = Vector3.zero;
        _rotation = Vector3.zero;

        MoveCamera();
        RotateCamera();
        ZoomCamera();
        
    }
    private void MoveCamera() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            _inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _inputMoveDir.x = +1f;
        }

        _move = transform.forward * _inputMoveDir.z + transform.right * _inputMoveDir.x;
        transform.position += _move * _moveSpeed * Time.deltaTime;
    }
    private void RotateCamera() 
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _rotation.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            _rotation.y = -1f;
        }

        transform.eulerAngles += _rotation * _rotationSpeed * Time.deltaTime;
    }

    private void ZoomCamera() 
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _targetFollowOffset.y -= _zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            _targetFollowOffset.y += _zoomAmount;
        }

        _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);
        _cmTransposer.m_FollowOffset = Vector3.Lerp(_cmTransposer.m_FollowOffset, _targetFollowOffset, Time.deltaTime * _zoomSpeed);
    }
}
