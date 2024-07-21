using UnityEngine;

[CreateAssetMenu(fileName = "ItemTreasure_", menuName = "Items/Treasure")]
public class ItemTreasure : InventoryItem
{
    public override bool UseItem()
    {
        return false;
    }
}
