using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Movables {
    [SerializeField] private float speed = 10f;

    private void Update() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hej");
        Destroy(gameObject);
    }

}
