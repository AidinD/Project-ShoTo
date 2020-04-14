using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    GameObject[] nozzle { get; set; }

    void Shoot();
}
