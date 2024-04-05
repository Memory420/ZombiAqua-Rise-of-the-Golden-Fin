using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Устанавливаем здоровье в максимальное значение при появлении объекта на сцене
        currentHealth = maxHealth;

        // Активируем любую дополнительную логику при появлении
        OnSpawn();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Дополнительная функция, активируемая при появлении объекта
    void OnSpawn()
    {
        // Здесь можно добавить код, который должен выполниться при появлении объекта
        Debug.Log(gameObject.name + " has spawned with " + currentHealth + " health.");
    }
}
