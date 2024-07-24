using UnityEngine;

[CreateAssetMenu(fileName = "ChestData", menuName = "Chest Data", order = 51)]
public class ChestData : ScriptableObject
{
    public bool isRewardGiven;
    public ChestItemReward weapon;
    public ChestItemReward mana;
    public ChestItemReward health;
}
