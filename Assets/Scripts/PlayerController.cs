using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMovable {

    [SerializeField] private float movementSpeed = 5f;

    private Vector3 screenBounds;
    private bool canShoot = true;

    private void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

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

    public void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
}
