using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats stats;

    [Header("Bars")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI levelTMP;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;

    [Header("Hearts")]
    [SerializeField] private Image[] hearts;

    [Header("Extra Panels")]
    [SerializeField] private GameObject playerQuestPanel;
    [SerializeField] private DialogueManager DialogueManager;
    [SerializeField] private PlayerDialog dialogue;

    [Header("Extra Panels")]
    [SerializeField] private Quest quest;
    [SerializeField] private QuestManager questManager;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource openPanelSound;

    private PlayerActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerActions();

        inputActions.UI.OpenInventory.performed += ctx => ToggleInventoryPanel();
        inputActions.UI.OpenQuest.performed += ctx => ToggleQuestPanel();
    }

    private void Update()
    {
        VerifyPuzzle();
        UpdatePlayerUI();
    }

    private void VerifyPuzzle()
    {
        if (quest.QuestCompleted && !quest.isRewardGiven)
        {
            DialogueManager.ShowDialogue(dialogue);
            audioSource.Play();
            questManager.AddToInventory(quest);
        }
    }

    public void OpenClosePlayerQuestPanel(bool value)
    {
        openPanelSound.Play();
        playerQuestPanel.SetActive(value);
    }

    public void OpenPuzzlePanel()
    {
        DialogueManager.CloseDialoguePuzzle();
        SceneManager.LoadScene("PuzzleScene");
    }

    private void UpdatePlayerUI()
    {

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            stats.Health / stats.MaxHealth, 10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount,
            stats.Mana / stats.MaxMana, 10f * Time.deltaTime);

        healthTMP.text = $"{stats.Health} / {stats.MaxHealth}";
        manaTMP.text = $"{stats.Mana} / {stats.MaxMana}";
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
    }

    private void OnDisable()
    {
        inputActions.UI.Disable();
    }

    private void ToggleInventoryPanel()
    {
        InventoryUI.Instance.OpenCloseInventory();
    }

    private void ToggleQuestPanel()
    {
        openPanelSound.Play();
        playerQuestPanel.SetActive(!playerQuestPanel.activeSelf);
    }

    // public void UpdateHeartsUI()
    // {
    //     for (int i = 0; i < stats.MaxLife; i++)
    //     {
    //         if (i < stats.Life)
    //         {
    //             hearts[i].sprite = fullHeart;
    //         }
    //         else
    //         {
    //             hearts[i].sprite = emptyHeart;
    //         }

    //         hearts[i].enabled = i < hearts.Length;
    //     }
    // }
}
