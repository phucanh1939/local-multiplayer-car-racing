// ReSharper disable InconsistentNaming

using System;
using UnityEngine;

[Serializable]
public class AxleInfo
{
    public WheelCollider leftWheelCollider;
    public WheelCollider rightWheelCollider;
    public GameObject leftWheelMesh;
    public GameObject rightWheelMesh;
    public bool motor;
    public bool steering;
}
