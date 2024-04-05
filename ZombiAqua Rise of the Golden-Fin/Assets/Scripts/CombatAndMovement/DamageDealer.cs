using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 10; // Урон, который наносит этот объект
    public bool isEnemy = false; // Помечает, принадлежит ли этот объект врагу

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Получаем компонент Health объекта, с которым произошло столкновение
        Health health = collision.gameObject.GetComponent<Health>();

        // Если у объекта, с которым произошло столкновение, есть компонент Health
        if (health != null)
        {
            // Проверяем, не является ли объект той же фракцией (например, враг не наносит урон врагу)
            DamageDealer targetDamageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if (targetDamageDealer != null && isEnemy == targetDamageDealer.isEnemy)
            {
                // Если объекты одной фракции, ничего не делаем
                return;
            }

            // Наносим урон
            health.TakeDamage(damage);

            // Здесь можно добавить дополнительную логику, например, уничтожение снаряда
            // Если это снаряд, то возможно вы захотите его уничтожить после попадания
            // Destroy(gameObject);
        }
    }
}
