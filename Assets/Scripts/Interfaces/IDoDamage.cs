using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoDamage
{
    int Damage { get; set; }
    void DoDamage(Collider2D other);
}
