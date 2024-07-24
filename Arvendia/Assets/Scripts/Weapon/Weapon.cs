using UnityEngine;

public enum WeaponType
{
    Magic,
    Fight,
    Consumable
}

[CreateAssetMenu(fileName = "Weapon_", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    [Header("Projectile")]
    public Projectile ProjectilePrefab;
    public float RequiredMana;

    [Header("Sound")]
    public AudioClip audioClip;
}

