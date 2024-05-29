using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireAngle = 45f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float angleInRadians = fireAngle * Mathf.Deg2Rad;
        Vector2 initialVelocity = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * bulletSpeed;

        rb.velocity = initialVelocity;
    }
}