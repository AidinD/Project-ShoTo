using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform[] nozzle;

    public Transform[] Nozzle { get; set; }

    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        Nozzle = nozzle;
    }

    public void Shoot(float speed)
    {
        if (Nozzle.Length > 0)
        {
            for (int i = 0; i < Nozzle.Length; i++)
            {
                var bullet = PoolManager.Instance.RequestFromPool("StandardBullet");
                bullet.transform.position = nozzle[i].transform.position;
                bullet.transform.rotation = nozzle[i].transform.rotation;
                bullet.GetComponent<Bullet>().MovementSpeed = speed;
            }
        }
    }
}
