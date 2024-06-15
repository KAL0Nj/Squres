using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject bulletPrefab; // 총알 프리팹 추가

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // 이동
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 총알 발사
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void FixedUpdate()
    {
        // 바닥 감지
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
    }

    void ShootBullet()
    {
        // 마우스 포인터 방향으로 총알 발사
        Vector3 mousePos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        Vector3 direction = (mousePos - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDirection(direction);
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
        // 플레이어 사망 처리
        gameObject.SetActive(false);
        SceneManager.LoadScene("사망");
    }
}