using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class PlayerController : MonoBehaviour, IMovable, IDamageable
{
    [SerializeField] private int health = 1;
    [SerializeField] private float movementSpeed = 5f;

    public int Health { get; set; }
    public float MovementSpeed { get; set; }

    private Vector3 screenBounds;
    private WeaponController weaponController;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
        Health = health;
        MovementSpeed = movementSpeed;
    }

    private void Start()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update()
    {
        Move();

        if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            weaponController.Shoot();
        }

        Teleport();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical) * MovementSpeed * Time.deltaTime;
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
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Todo Die and stuff
    }
}
