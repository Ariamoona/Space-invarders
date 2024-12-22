using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    private bool _laserActive;

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        
        float clampedX = Mathf.Clamp(transform.position.x, -14f, 14f);
        transform.position = new Vector2(clampedX, transform.position.y);
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") |
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            _laserActive = false;
        }
    }
}