using UnityEngine;

public enum WeaponType
{
    Magic,
    Fight
}

[CreateAssetMenu(fileName = "Weapon_", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    [Header("Projectile")]
    public Projectile ProjectilePrefab;
    public float RequiredMana;
}

