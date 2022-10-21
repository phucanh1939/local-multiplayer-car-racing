using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector3.forward * (_speed * Time.fixedDeltaTime));
    }
}
