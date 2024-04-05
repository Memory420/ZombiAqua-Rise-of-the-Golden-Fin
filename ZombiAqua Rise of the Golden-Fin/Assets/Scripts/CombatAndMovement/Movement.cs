using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool attack = false; // Добавляем переменную для отслеживания запроса на атаку

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // Проверяем нажатие ЛКМ
        if (Input.GetMouseButtonDown(0)) // 0 - это ЛКМ
        {
            attack = true;
        }
    }

    void FixedUpdate()
    {
        // Передаем все состояния действий в контроллер персонажа
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, attack);
        jump = false; // Сбрасываем после прыжка

        if (attack)
        {
            // Сбрасываем флаг атаки после ее обработки
            attack = false;
        }
    }
}
