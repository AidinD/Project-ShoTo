using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {
    Transform[] Nozzle { get; set; }

    void Shoot(float speed);
}
