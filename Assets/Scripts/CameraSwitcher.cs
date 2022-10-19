using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private Camera _frontCamera;
    [SerializeField] private Camera _backCamera;
    [SerializeField] private KeyCode _switchKey = KeyCode.LeftShift;

    private void Start()
    {
        _frontCamera.enabled = false;
        _backCamera.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_switchKey))
        {
            _frontCamera.enabled = !_frontCamera.enabled;
            _backCamera.enabled = !_backCamera.enabled;
        }
    }
}
