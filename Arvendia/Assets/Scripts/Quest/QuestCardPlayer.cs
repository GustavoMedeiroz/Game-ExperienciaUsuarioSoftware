using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestCardPlayer : QuestCard
{
    [Header("Config")]
    [SerializeField] private TextMeshProUGUI statusTMP;
    [SerializeField] private GameObject imageConcluida;
    [SerializeField] private GameObject imagePendente;

    private void Update()
    {
        if (QuestToComplete.hasProgress && !QuestToComplete.QuestCompleted)
        {
            statusTMP.text =
                $"Status\n{QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
            imagePendente.SetActive(false);
            imageConcluida.SetActive(false);
        }
        else if (QuestToComplete.hasProgress && QuestToComplete.QuestCompleted)
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(false);
            imageConcluida.SetActive(true);
        }
        else if (QuestToComplete.QuestCompleted)
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(false);
            imageConcluida.SetActive(true);

        }
        else
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(true);
            imageConcluida.SetActive(false);
        }
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);

        if (quest.hasProgress && !quest.QuestCompleted)
        {
            statusTMP.text =
                $"Status\n{QuestToComplete.CurrentStatus}/{QuestToComplete.QuestGoal}";
            imagePendente.SetActive(false);
            imageConcluida.SetActive(false);
        }
        else if (quest.hasProgress && quest.QuestCompleted)
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(false);
            imageConcluida.SetActive(true);
        }
        else if (quest.QuestCompleted)
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(false);
            imageConcluida.SetActive(true);

        }
        else
        {
            statusTMP.enabled = false;
            imagePendente.SetActive(true);
            imageConcluida.SetActive(false);
        }
    }

    private void QuestCompletedCheck()
    {
        if (QuestToComplete.QuestCompleted)
        {
            Debug.Log("Quest completada");
            statusTMP.enabled = false;
            if (Inventory.Instance == null)
            {
                Debug.LogError("Instância do inventário é nula.");
                return;
            }
            imagePendente.SetActive(false);
            imageConcluida.SetActive(true);
        }
    }

    private void OnEnable()
    {
        QuestCompletedCheck();
    }
}
