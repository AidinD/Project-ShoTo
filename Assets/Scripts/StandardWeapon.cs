using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : MonoBehaviour, IWeapon {
    [SerializeField] private Transform[] nozzle;

    public Transform[] Nozzle { get; set; }

    [SerializeField] private GameObject bulletPrefab;

    private void Start() {
        Nozzle = nozzle;
        Debug.Log("hejsasn " + Nozzle.Length);
    }

    public void Shoot() {
        if (Nozzle.Length > 0) {
            for (int i = 0; i < Nozzle.Length; i++) {
                Instantiate(bulletPrefab, Nozzle[i].transform.position, Quaternion.identity);
            }
        }
    }
}
