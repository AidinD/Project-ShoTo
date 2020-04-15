using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovable {

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private GameObject[] weaponTypes;

    private Vector3 screenBounds;
    private bool canShoot = true;
    private GameObject weaponType;
    private IWeapon weapon;

    private void Awake() {
        SetWeaponType(weaponTypes[0]);
        //weapon = weapons[0].GetComponent<IWeapon>();
    }

    private void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update() {
        MovePlayer();

        if ((Input.GetButton("Jump") || Input.GetButton("Fire1")) && canShoot) {
            Shoot();
            canShoot = false;
        }
    }

    private void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical) * movementSpeed * Time.deltaTime;
        Teleport();
    }

    private void Shoot() {
        weapon.Shoot();
        StartCoroutine(ShootCoolDown(0.2f));
    }

    private IEnumerator ShootCoolDown(float coolDown) {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

    public void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    public void SetWeaponType(GameObject newWeaponType) {
        weaponType?.SetActive(false);
        weaponType = newWeaponType;
        weaponType.SetActive(true);
        weapon = weaponType.GetComponent<IWeapon>();
    }
}
