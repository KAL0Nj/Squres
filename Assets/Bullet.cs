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
        // 총알 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 적 오브젝트와 충돌 시 적 사망 처리
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
