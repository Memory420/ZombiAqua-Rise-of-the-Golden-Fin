using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 10; // ����, ������� ������� ���� ������
    public bool isEnemy = false; // ��������, ����������� �� ���� ������ �����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������� ��������� Health �������, � ������� ��������� ������������
        Health health = collision.gameObject.GetComponent<Health>();

        // ���� � �������, � ������� ��������� ������������, ���� ��������� Health
        if (health != null)
        {
            // ���������, �� �������� �� ������ ��� �� �������� (��������, ���� �� ������� ���� �����)
            DamageDealer targetDamageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if (targetDamageDealer != null && isEnemy == targetDamageDealer.isEnemy)
            {
                // ���� ������� ����� �������, ������ �� ������
                return;
            }

            // ������� ����
            health.TakeDamage(damage);

            // ����� ����� �������� �������������� ������, ��������, ����������� �������
            // ���� ��� ������, �� �������� �� �������� ��� ���������� ����� ���������
            // Destroy(gameObject);
        }
    }
}
