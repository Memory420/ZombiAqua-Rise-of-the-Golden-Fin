using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // ������������� �������� � ������������ �������� ��� ��������� ������� �� �����
        currentHealth = maxHealth;

        // ���������� ����� �������������� ������ ��� ���������
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

    // �������������� �������, ������������ ��� ��������� �������
    void OnSpawn()
    {
        // ����� ����� �������� ���, ������� ������ ����������� ��� ��������� �������
        Debug.Log(gameObject.name + " has spawned with " + currentHealth + " health.");
    }
}
