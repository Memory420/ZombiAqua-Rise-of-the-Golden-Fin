using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ��������, �� ������� ������� ������
    public float smoothing = 5f; // �������� �����������
    public float minX;
    public float maxX;
    public float yOffset; // ����� �� ��� Y

    Vector3 offset; // �������� ����� ������� � ����������

    void Start()
    {
        // ������������ ��������
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // ��������� ����� ������� ������
        Vector3 targetCamPos = target.position + offset;

        // ��������� �������� �� ��� Y
        targetCamPos.y += yOffset;

        // ������������ ����� ������� � �������� minX � maxX
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minX, maxX);

        // ������ ���������� ������ � ����� �������
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}