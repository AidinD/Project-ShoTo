using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Entities/Bullet", order = 1)]
public class BulletSO : ScriptableObject
{
    public string BulletName = "";
    public int MaxHealth = 0;
    public int Damage = 0;

    public Sprite Sprite = null;

    public float MovementSpeed { get; set; }

    [HideInInspector]
    public int CurrentHealth = 0;
}
