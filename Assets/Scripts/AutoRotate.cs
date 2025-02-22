using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
    public Transform circleCenter; // 원의 가운데 위치
    public Transform line; // 회전할 선

    private bool isRotating = false; // Flag to track rotation status

    public float origin;
    public float rotationSpeed = 10f; // 회전 속도 (각도/초)

    private void Update()
    {
        float angle = Time.time * rotationSpeed; // 초당 회전 각도 계산
        transform.rotation = Quaternion.Euler(0f, 0f, origin-angle);
    }

    /*
    public void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;

        float totalRotation = 0f; // Total rotation angle
        float targetRotation = 360f; // Target rotation angle

        while (totalRotation < targetRotation)
        {
            // Rotate the object based on the rotation speed
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationAmount);

            totalRotation += rotationAmount;

            yield return null;
        }

        isRotating = false;
    }
    */
}
