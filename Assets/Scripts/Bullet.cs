using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IMovable {
    public float Speed { get; set; }

    private Vector3 screenBounds;
    private bool canShoot = true;

    private void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update() {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
        // Todo object pooling
    }

    public void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
}
