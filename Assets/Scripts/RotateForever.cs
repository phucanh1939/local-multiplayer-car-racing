using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForever : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _axis;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_axis, _speed * Time.deltaTime);
    }
}
