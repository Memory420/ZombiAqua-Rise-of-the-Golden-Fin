using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool attack = false; // ��������� ���������� ��� ������������ ������� �� �����

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // ��������� ������� ���
        if (Input.GetMouseButtonDown(0)) // 0 - ��� ���
        {
            attack = true;
        }
    }

    void FixedUpdate()
    {
        // �������� ��� ��������� �������� � ���������� ���������
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, attack);
        jump = false; // ���������� ����� ������

        if (attack)
        {
            // ���������� ���� ����� ����� �� ���������
            attack = false;
        }
    }
}
