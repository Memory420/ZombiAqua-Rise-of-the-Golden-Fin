using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false; // ��������� ���������� ��� ������������ ������� �� ������

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // �������� �� ������� ������ ������ � ���� �����
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // �������� Move � ������� �������������� ��������� � �������� ������
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false; // ����� ����� ������, ����� �������� ���������� ������
    }
}
