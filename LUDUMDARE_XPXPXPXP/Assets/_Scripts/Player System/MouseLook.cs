using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSens; // 2f
    private float maxYangle = 80f;

    private float _rotationX = 0;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * MouseSens);

        _rotationX -= mouseY * MouseSens;
        _rotationX = Mathf.Clamp(_rotationX, -maxYangle, maxYangle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
    }
}
