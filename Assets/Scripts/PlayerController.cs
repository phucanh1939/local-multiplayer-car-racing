using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _turnSpeed = 5.0f;

    private float _horizontalInput;
    private float _verticalInput;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up, _turnSpeed * Time.fixedDeltaTime * _horizontalInput);
        _transform.Translate(_speed * Time.fixedDeltaTime * _verticalInput * Vector3.forward);
    }

}
