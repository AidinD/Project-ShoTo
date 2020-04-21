using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMovable, IDamageable, IDoDamage, IPooledObject
{
    [SerializeField] private int damage = 1;
    [SerializeField] private int health = 1;

    public int Health { get; set; }
    public float MovementSpeed { get; set; }
    public int Damage { get; set; }

    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update()
    {
        Move();
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DoDamage(other);
        TakeDamage(1);
    }

    public void OnObjectSpawn()
    {
        Health = health;
        Damage = damage;
    }

    public void DoDamage(Collider2D other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(Damage);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.up * MovementSpeed * Time.deltaTime);
    }

    public void Teleport()
    {
        if (Mathf.Abs(transform.position.x) > screenBounds.x)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnObjectDestroy();
        // Todo object pooling
    }

    public void OnObjectDestroy()
    {
        PoolManager.Instance.ReturnToPool("StandardBullet", gameObject);
    }
}