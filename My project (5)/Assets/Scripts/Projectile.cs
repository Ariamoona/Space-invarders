using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dirrection;
    public float speed;
    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += this.dirrection * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.destroyed != null)
        {
        this.destroyed.Invoke();
        }
        
        Destroy(this.gameObject);
    }
}
