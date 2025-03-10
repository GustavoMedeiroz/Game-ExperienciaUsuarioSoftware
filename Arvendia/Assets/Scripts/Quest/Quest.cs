using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest_", menuName = "Quest")]
public class Quest : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string ID;
    public int QuestGoal;

    [Header("Description")]
    public string Description;

    [Header("Info")]
    public bool hasProgress;

    [Header("Reward")]
    public QuestItemReward Reward_Key;
    public QuestItemReward Reward_Mana;
    public QuestItemReward Reward_Health;

    //[HideInInspector]
    public int CurrentStatus;
    public bool QuestCompleted;
    public bool isRewardGiven;

    public void AddProgress(int amount)
    {
        CurrentStatus += amount;
        if (CurrentStatus >= QuestGoal)
        {
            CurrentStatus = QuestGoal;
            QuestIsCompleted();
        }
    }

    private void QuestIsCompleted()
    {
        if (QuestCompleted)
        {
            return;
        }

        QuestCompleted = true;
    }

    public void ResetQuest()
    {
        QuestCompleted = false;
        CurrentStatus = 0;
        isRewardGiven = false;
    }

}

[Serializable]
public class QuestItemReward
{
    public InventoryItem Item;
    public int Quantity;
}
