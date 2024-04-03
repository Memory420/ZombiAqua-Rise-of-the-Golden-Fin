using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite pressedSprite;
    public UnityEvent onPressed;
    public AudioClip clickSound;

    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;
    private AudioSource audioSource;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;
        audioSource.volume = 0.1f;
    }

    void OnMouseDown()
    {
        spriteRenderer.sprite = pressedSprite;
        isPressed = true;

        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
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
        // Дописать события на нажатие
    }

    public void NewGame()
    {
        Debug.Log("New Game");
        // Дописать события на нажатие
    }

    public void Exit()
    {
        Debug.Log("Exit");
        // Дописать события на нажатие
    }
}