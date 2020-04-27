using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity, IPooledObject
{
    [SerializeField] private BulletSO bullet;

    public BulletSO BulletType { get { return bullet; } private set { } }

    protected override void Awake()
    {
        base.Awake();
        BulletType = bullet;

    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        DoDamage(other);
        TakeDamage(1);
    }

    protected override void Move()
    {
        transform.Translate(Vector3.up * bullet.MovementSpeed * Time.deltaTime);
    }


    private void DoDamage(Collider2D other)
    {
        var hit = other.gameObject.GetComponent<Entity>();
        hit?.TakeDamage(bullet.Damage);
    }

    public override void TakeDamage(int damage)
    {
        bullet.CurrentHealth -= damage;
        if (bullet.CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        OnObjectDestroy();
    }

    public void OnObjectSpawn()
    {
        bullet.CurrentHealth = bullet.MaxHealth;
    }

    public void OnObjectDestroy()
    {
        PoolManager.Instance.ReturnToPool(bullet.BulletName, gameObject);
    }
}