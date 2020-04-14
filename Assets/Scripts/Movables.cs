using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movables : MonoBehaviour {

    protected Vector3 screenBounds;

    protected virtual void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    protected void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
}
