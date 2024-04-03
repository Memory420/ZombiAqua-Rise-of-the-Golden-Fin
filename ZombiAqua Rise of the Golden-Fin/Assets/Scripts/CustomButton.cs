using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite pressedSprite;
    public UnityEvent onPressed;

    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = pressedSprite;
        isPressed = true;
    }

    void OnMouseUp()
    {
        if (isPressed)
        {
            onPressed.Invoke();
            spriteRenderer.sprite = defaultSprite;
            isPressed = false;
        }
    }
    public void Continue()
    {
        Debug.Log("Continue");
    }
    public void NewGame()
    {
        Debug.Log("New Game");
    }
    public void Exit()
    {
        Debug.Log("Exit");
    }
}

