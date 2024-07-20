using System;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject dialogPanelPuzzle;
    [SerializeField] private Image playerIconPuzzle;
    [SerializeField] private TextMeshProUGUI playerNameTMPPuzzle;
    [SerializeField] private TextMeshProUGUI playerDialogTMPPuzzle;

    [SerializeField] private GameObject dialogPanelNormal;
    [SerializeField] private Image playerIcon;
    [SerializeField] private TextMeshProUGUI playerNameTMP;
    [SerializeField] private TextMeshProUGUI playerDialogTMP;

    public void ShowDialogue(PlayerDialog playerDialog)
    {
        if (!playerDialog.CanShow) return;

        if (playerDialog.type is TypeDialog.puzzleQuest && playerDialog.CanShow)
        {
            dialogPanelPuzzle.SetActive(true);
            playerIconPuzzle.sprite = playerDialog.Icon;
            playerNameTMPPuzzle.text = playerDialog.name;
            playerDialogTMPPuzzle.text = playerDialog.Dialogue;
        }
        else
        {
            dialogPanelNormal.SetActive(true);
            playerIcon.sprite = playerDialog.Icon;
            playerNameTMP.text = playerDialog.name;
            playerDialogTMP.text = playerDialog.Dialogue;
        }
    }

    public void CloseDialoguePuzzle()
    {
        dialogPanelPuzzle.SetActive(false);
    }

    public void CloseDialogueNormal()
    {
        dialogPanelNormal.SetActive(false);
    }

}