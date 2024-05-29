using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 9.81f;
    private Vector2 velocity;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
    }

    void Update()
    {
        Vector2 position = transform.position;
        position += velocity * Time.deltaTime;

        velocity.y -= gravity * Time.deltaTime;

        transform.position = position;
    }
}