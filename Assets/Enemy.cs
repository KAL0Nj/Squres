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
        // �÷��̾� ���� �� ����
        if (Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // �÷��̾� �������� �̵�
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
        // �� ��� ó��
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾�� �浹 �� �÷��̾� ��� ó��
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().TakeDamage(maxHealth);
        }
    }
}
