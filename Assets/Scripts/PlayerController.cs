using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movables {

    [SerializeField] private float movementSpeed = 5f;

    private bool canShoot = true;

    private void Update() {
        MovePlayer();

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) && canShoot) {
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
        Debug.Log("can shoot");
        StartCoroutine(ShootCoolDown(2f));
    }

    private IEnumerator ShootCoolDown(float coolDown) {
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }

}
