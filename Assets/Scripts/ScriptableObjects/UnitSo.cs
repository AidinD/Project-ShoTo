using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Entities/Enemy", order = 1)]
public class UnitSo : ScriptableObject
{
    public string UnitName = "";
    public int MaxHealth = 0;
    public int BaseDamage = 0;
    public float MovementSpeed = 0;
    public int Points;

    public Sprite Sprite = null;

    [HideInInspector]
    public int CurrentHealth = 0;
}
