using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Jigsaw - Lock")]
    [SerializeField] private GameObject dialogPanelPuzzle;
    [SerializeField] private Image playerIconPuzzle;
    [SerializeField] private TextMeshProUGUI playerNameTMPPuzzle;
    [SerializeField] private TextMeshProUGUI playerDialogTMPPuzzle;

    [Header("Jigsaw - Lock")]
    [SerializeField] private GameObject dialogPanelNormal;
    [SerializeField] private Image playerIcon;
    [SerializeField] private TextMeshProUGUI playerNameTMP;
    [SerializeField] private TextMeshProUGUI playerDialogTMP;

    [Header("Jigsaw - Lock")]
    [SerializeField] private GameObject dialogJigsawPanel;
    [SerializeField] private Image playerJgsawIcon;
    [SerializeField] private TextMeshProUGUI playerJigsawNameTMP;
    [SerializeField] private TextMeshProUGUI playerJigsawDialogTMP;

    public void ShowDialogue(PlayerDialog playerDialog)
    {
        if (playerDialog.type is TypeDialog.puzzleQuest)
        {
            dialogPanelPuzzle.SetActive(true);
            playerIconPuzzle.sprite = playerDialog.Icon;
            playerNameTMPPuzzle.text = playerDialog.name;
            playerDialogTMPPuzzle.text = playerDialog.Dialogue;
        }
        else if (playerDialog.type is TypeDialog.jigsawQuest)
        {
            dialogJigsawPanel.SetActive(true);
            playerJgsawIcon.sprite = playerDialog.Icon;
            playerJigsawNameTMP.text = playerDialog.name;
            playerJigsawDialogTMP.text = playerDialog.Dialogue;
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