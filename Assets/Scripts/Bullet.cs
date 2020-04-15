using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMovable, IDamageable {
    [SerializeField] private int damage = 1;
    [SerializeField] private int health = 1;

    public float Speed { get; set; }
    public int Health { get; set; }

    private Vector3 screenBounds;

    private void Awake() {
        Health = health;
    }

    private void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update() {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TakeDamage(1);
    }

    public void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    public void TakeDamage(int damage) {
        Health -= damage;
        if (Health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
        // Todo object pooling
    }
}
