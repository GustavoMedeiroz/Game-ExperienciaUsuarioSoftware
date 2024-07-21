using UnityEngine;

public class QuestManagerPuzzle : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest quests;

    public void AddToInventory(Quest quest)
    {

        Inventory inventory = Inventory.Instance;
        if (inventory == null)
        {
            Debug.Log("Inventário null");
            return;
        }
        Inventory.Instance.AddItem(quest.Reward_Key.Item, quest.Reward_Key.Quantity);
        Inventory.Instance.AddItem(quest.Reward_Mana.Item, quest.Reward_Mana.Quantity);
        Inventory.Instance.AddItem(quest.Reward_Health.Item, quest.Reward_Health.Quantity);
        quest.isRewardGiven = true;
    }
}
