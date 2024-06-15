using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject bulletPrefab; // �Ѿ� ������ �߰�

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // �̵�
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void FixedUpdate()
    {
        // �ٴ� ����
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
    }

    void ShootBullet()
    {
        // ���콺 ������ �������� �Ѿ� �߻�
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
        // �÷��̾� ��� ó��
        gameObject.SetActive(false);
        SceneManager.LoadScene("���");
    }
}