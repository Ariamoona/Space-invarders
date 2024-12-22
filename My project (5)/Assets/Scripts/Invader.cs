using System;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    public Action killed { get; internal set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }
    private
    void AnimateSprite()
    {
        _animationFrame++;
        if (_animationFrame >= this.animationSprites.Length)
        
        {
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
        }
    }

    public float moveSpeed = 2f;
    private bool movingRight = true;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * (movingRight ? 1 : -1));

        if (transform.position.x > 14f || transform.position.x < -14f)
        {
            movingRight = !movingRight;
            transform.position += Vector3.down * 0.5f; // Снижаем врага вниз при смене направления
        }
    }
}
