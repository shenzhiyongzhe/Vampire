using UnityEngine;

public class MagicWand : Weapon
{
    EnemySpawner enemySpawner;
    Vector2 enemyPos;

    private void OnEnable()
    {
        if(enemySpawner != null)
        {
            enemyPos = enemySpawner.GetRandomPos();
        }
    }
    private void Start()
    {
        enemySpawner = EnemySpawner.Instance;
    }
    private void Update()
    {
        if(enemyPos != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyPos, AttackSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            InactivateWeapon();
        }
    }

}