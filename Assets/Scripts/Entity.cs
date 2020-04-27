using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private Vector3 screenBounds;

    protected virtual void Awake()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    protected virtual void Update()
    {
        Move();
        Teleport();
    }

    public abstract void TakeDamage(int damage);
    protected abstract void Move();
    protected abstract void Die();

    private void Teleport()
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
