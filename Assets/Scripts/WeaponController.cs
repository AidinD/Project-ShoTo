using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    [SerializeField] private float bulletSpeed = 6f;
    [SerializeField] private GameObject[] weaponTypes;

    private GameObject weaponType;
    private IWeapon weapon;
    private bool canShoot = true;

    private void Awake() {
        SetWeaponType(weaponTypes[1]);
    }

    public void Shoot() {
        if (canShoot) {
            weapon.Shoot(bulletSpeed);
            canShoot = false;
            StartCoroutine(ShootCoolDown(0.2f));
        }
    }

    public void SetWeaponType(GameObject newWeaponType) {
        weaponType?.SetActive(false);
        weaponType = newWeaponType;
        weaponType.SetActive(true);
        weapon = weaponType.GetComponent<IWeapon>();
    }

    private IEnumerator ShootCoolDown(float coolDown) {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
