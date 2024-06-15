using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f;

    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void Update()
    {
        // �Ѿ� �̵�
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �� ������Ʈ�� �浹 �� �� ��� ó��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
