using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour, IMovable, IDamageable, IGivePoints
{
    [SerializeField] private int health = 1;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private int points = 10;

    public int Health { get; set; }
    public float MovementSpeed { get; set; }
    public int Points { get; set; }

    private Vector3 screenBounds;

    private void Awake()
    {
        Health = health;
        MovementSpeed = movementSpeed;
        Points = points;
    }

    private void Start()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update()
    {
        Move();
        Teleport();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.down * MovementSpeed * Time.deltaTime);
    }

    public void Die()
    {
        GivePoints();
        Destroy(gameObject);
        // Todo Die and stuff
    }

    public void GivePoints()
    {
        // Call some manager and give points
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
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

}
