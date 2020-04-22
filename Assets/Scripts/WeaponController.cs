using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 6f;
    [SerializeField] private float coolDown = 0.2f;
    [SerializeField] private GameObject[] weaponTypes;

    public float BulletSpeed { get; set; }
    public float CoolDown { get; set; }
    private GameObject weaponType;
    private IWeapon weapon;
    private bool canShoot = true;

    private void Awake()
    {
        SetWeaponType(weaponTypes[0].name);
        CoolDown = coolDown;
        BulletSpeed = bulletSpeed;
    }

    public void Shoot()
    {
        if (canShoot)
        {
            weapon.Shoot(BulletSpeed);
            canShoot = false;
            StartCoroutine(ShootCoolDown(CoolDown));
        }
    }

    public void SetWeaponType(string newWeaponTypeName)
    {
        weaponType?.SetActive(false);
        var weaponInArray = weaponTypes.FirstOrDefault(w => w.name == newWeaponTypeName);
        weaponType = weaponInArray;
        weaponType.SetActive(true);
        weapon = weaponType.GetComponent<IWeapon>();
    }

    private IEnumerator ShootCoolDown(float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
