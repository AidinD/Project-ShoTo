using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour, IMovable, IDamageable, IGivePoints, IPooledObject
{
    [SerializeField] private string poolTag;
    [SerializeField] private int health = 1;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private int points = 10;

    public int Health { get; set; }
    public float MovementSpeed { get; set; }
    public int Points { get; set; }
    public string PoolTag { get { return poolTag; } }

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

    public virtual void Move()
    {
        transform.Translate(Vector3.down * MovementSpeed * Time.deltaTime);
    }

    public void Die()
    {
        GivePoints();
        OnObjectDestroy();
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

    public virtual string GetTag()
    {
        return "EnemyController";
    }

    public void OnObjectSpawn()
    {
        Debug.Log("movement SPeed" + movementSpeed);
        Health = health;
        MovementSpeed = movementSpeed;
        Points = points;
    }

    public void OnObjectDestroy()
    {
        PoolManager.Instance.ReturnToPool(poolTag, gameObject);
    }
}
