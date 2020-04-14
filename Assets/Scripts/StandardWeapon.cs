using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardWeapon : MonoBehaviour, IWeapon {

    [SerializeField]
    public GameObject[] nozzle { get; set; }

    private void Awake() {

    }

    public void Shoot() {
        throw new System.NotImplementedException();
    }
}
