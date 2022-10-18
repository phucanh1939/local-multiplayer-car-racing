using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private Transform _transform;

    [Header("Movement")]
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _turnSpeed = 5.0f;

    [Header("Cameras")]
    [SerializeField] private Camera _frontCamera;
    [SerializeField] private Camera _backCamera;
    [SerializeField] private KeyCode _cameraSwitchKey = KeyCode.LeftShift;

    private void Awake()
    {
        _transform = transform;
        _frontCamera.enabled = false;
        _backCamera.enabled = true;
    }

    private void Update()
    {
        UpdateMovementInput();
        UpdateCameras();
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _turnSpeed * Time.fixedDeltaTime * _horizontalInput);
        _transform.Translate(_speed * Time.fixedDeltaTime * _verticalInput * Vector3.forward);
    }

    private void UpdateMovementInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void UpdateCameras()
    {
        if (Input.GetKeyDown(_cameraSwitchKey))
        {
            _frontCamera.enabled = !_frontCamera.enabled;
            _backCamera.enabled = !_backCamera.enabled;
        }
    }

}
