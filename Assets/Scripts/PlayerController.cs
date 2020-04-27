using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class PlayerController : Entity
{
    [SerializeField] private UnitSo unit;

    public UnitSo UnityType { get { return unit; } private set { } }

    private WeaponController weaponController;

    protected override void Awake()
    {
        base.Awake();
        weaponController = GetComponent<WeaponController>();
        UnityType = unit;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
        {
            weaponController.Shoot();
        }
    }

    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical) * unit.MovementSpeed * Time.deltaTime;
    }

    public override void TakeDamage(int damage)
    {
        unit.CurrentHealth -= damage;
        if (unit.CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        // Todo Die and stuff
    }
}
