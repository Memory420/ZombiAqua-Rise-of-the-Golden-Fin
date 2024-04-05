using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false; // Добавлена переменная для отслеживания запроса на прыжок

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Проверка на нажатие кнопки прыжка в этом кадре
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // Вызываем Move с текущим горизонтальным движением и статусом прыжка
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false; // Сброс после прыжка, чтобы избежать повторного прыжка
    }
}
