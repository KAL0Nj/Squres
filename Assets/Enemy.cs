using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public float moveSpeed = 3f;
    public float detectionRange = 10f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        // 플레이어 감지 및 추적
        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // 플레이어 방향으로 이동
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 적 사망 처리
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어와 충돌 시 플레이어 사망 처리
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().TakeDamage(maxHealth);
        }
    }
}
