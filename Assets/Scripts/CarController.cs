using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private List<AxleInfo> _axleInfos;
    [SerializeField] private float _maxMotorTorque = 30;
    [SerializeField] private float _maxSteeringAngle = 50;
    [SerializeField] private float _brakeTorque = 15;
    [SerializeField] private float _decelerationForce = 15;
    [SerializeField] private KeyCode _brakeKey = KeyCode.Space;
    [SerializeField] private Vector3 _centerOfMass;

    private string _verticalAxisName;
    private string _horizontalAxisName;
    private float _verticalInput;
    private float _horizontalInput;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = _centerOfMass;
        _verticalAxisName = _id > 0 ? "Vertical" + "_" + _id : "Vertical";
        _horizontalAxisName = _id > 0 ? "Horizontal" + "_" + _id : "Horizontal";
    }

    private void FixedUpdate()
    {
        GetInput();
        UpdateWheels();
    }

    private void GetInput()
    {
        _verticalInput = Input.GetAxis(_verticalAxisName);
        _horizontalInput = Input.GetAxis(_horizontalAxisName);
    }

    private void UpdateWheels()
    {
        var motorTorque = _maxMotorTorque * _verticalInput;
        var steerAngle = _maxSteeringAngle * _horizontalInput;
        foreach (var axle in _axleInfos)
        {
            UpdateAxle(axle, motorTorque, steerAngle);
        }
    }

    private void UpdateAxle(AxleInfo axle, float motorTorque, float steerAngle)
    {
        axle.leftWheelCollider.brakeTorque = 0;
        axle.rightWheelCollider.brakeTorque = 0;
        if (axle.steering) Steer(axle, steerAngle);
        if (axle.motor) Acceleration(axle, motorTorque);
        if (Input.GetKey(_brakeKey)) Brake(axle);
        UpdateWheelModels(axle);
    }

    private void Acceleration(AxleInfo axleInfo, float motorTorque)
    {
        if (motorTorque != 0f)
        {
            axleInfo.leftWheelCollider.motorTorque = motorTorque;
            axleInfo.rightWheelCollider.motorTorque = motorTorque;
        }
        else
        {
            Deceleration(axleInfo);
        }
    }

    private void Deceleration(AxleInfo axleInfo)
    {
        axleInfo.leftWheelCollider.brakeTorque = _decelerationForce;
        axleInfo.rightWheelCollider.brakeTorque = _decelerationForce;
    }

    private void Steer(AxleInfo axleInfo, float steerAngle)
    {
        if (!axleInfo.steering) return;
        axleInfo.leftWheelCollider.steerAngle = steerAngle;
        axleInfo.rightWheelCollider.steerAngle = steerAngle;
    }

    private void Brake(AxleInfo axleInfo)
    {
        axleInfo.leftWheelCollider.brakeTorque = _brakeTorque;
        axleInfo.rightWheelCollider.brakeTorque = _brakeTorque;
    }

    /// <summary>
    /// Update wheel models transform to match wheel colliders
    /// </summary>
    /// <param name="axleInfo"></param>
    private void UpdateWheelModels(AxleInfo axleInfo)
    {
        axleInfo.leftWheelCollider.GetWorldPose(out var position, out var rotation);
        axleInfo.leftWheelMesh.transform.position = position;
        axleInfo.leftWheelMesh.transform.rotation = rotation;
        axleInfo.rightWheelCollider.GetWorldPose(out position, out rotation);
        axleInfo.rightWheelMesh.transform.position = position;
        axleInfo.rightWheelMesh.transform.rotation = rotation;
    }
}