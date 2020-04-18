using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGivePoints
{
    int Points { get; set; }
    void GivePoints();
}
