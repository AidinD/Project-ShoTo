using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity, IPooledObject
{
    [SerializeField] protected UnitSo unit;

    public UnitSo UnitType { get { return unit; } private set { } }

    protected override void Awake()
    {
        base.Awake();
        UnitType = unit;
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * unit.MovementSpeed * Time.deltaTime);
    }

    protected override void Die()
    {
        GivePoints();
        OnObjectDestroy();
        // Todo Die and stuff
    }

    public void GivePoints()
    {
        // Call some manager and give points
    }

    public override void TakeDamage(int damage)
    {
        unit.CurrentHealth -= damage;
        if (unit.CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual string GetTag()
    {
        return "EnemyController";
    }

    public void OnObjectSpawn()
    {
        unit.CurrentHealth = unit.MaxHealth;
    }

    public void OnObjectDestroy()
    {
        PoolManager.Instance.ReturnToPool(unit.UnitName, gameObject);
    }
}
