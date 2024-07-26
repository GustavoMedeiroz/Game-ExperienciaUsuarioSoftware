using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "ItemWeapon")]
public class ItemWeapon : InventoryItem
{
    [Header("Weapon")]
    public Weapon Weapon;

    public override bool UseItem()
    {
        return false;
    }

    public override void EquipItem()
    {
        WeaponManager.Instance.EquipWeapon(Weapon);
    }
}
