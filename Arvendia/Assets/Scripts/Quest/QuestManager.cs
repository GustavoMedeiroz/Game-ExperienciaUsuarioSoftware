using System;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] quests;

    [Header("Player Quest Panel")]
    [SerializeField] private QuestCardPlayer questCardPlayerPrefab;
    [SerializeField] private Transform playerQuestContainer;

    private void Start()
    {
        LoadQuestsIntroPlayerPanel();
    }

    public void AddProgress(string questID, int amount)
    {
        Quest questToUpdate = QuestExists(questID);
        if (questToUpdate == null) return;

        questToUpdate.AddProgress(amount);

    }

    public void AddToInventory(Quest quest)
    {
        if (quest.Reward_Key != null)
        {
            Inventory.Instance.AddItem(quest.Reward_Key.Item, quest.Reward_Key.Quantity);
        }

        Inventory.Instance.AddItem(quest.Reward_Mana.Item, quest.Reward_Mana.Quantity);
        Inventory.Instance.AddItem(quest.Reward_Health.Item, quest.Reward_Health.Quantity);
        quest.isRewardGiven = true;
    }

    private Quest QuestExists(string questID)
    {
        foreach (Quest quest in quests)
        {
            if (quest.ID == questID)
            {
                return quest;
            }
        }

        return null;
    }

    private void LoadQuestsIntroPlayerPanel()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            QuestCard cardPlayer = Instantiate(questCardPlayerPrefab, playerQuestContainer);
            cardPlayer.ConfigQuestUI(quests[i]);
        }
    }

    private void OnEnable()
    {
        // for (int i = 0; i < quests.Length; i++)
        // {
        //     quests[i].ResetQuest();
        // }
    }
}