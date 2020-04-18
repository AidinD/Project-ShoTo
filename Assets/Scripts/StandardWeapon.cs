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
                // Todo object pooling
                var bullet = Instantiate(bulletPrefab, Nozzle[i].transform.position, Nozzle[i].rotation);
                bullet.GetComponent<Bullet>().MovementSpeed = speed;
            }
        }
    }
}
