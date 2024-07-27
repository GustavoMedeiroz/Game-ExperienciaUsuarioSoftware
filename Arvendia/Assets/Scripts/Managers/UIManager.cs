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
    [SerializeField] private PlayerDialog dialoguePuzzleComplete;
    [SerializeField] private PlayerDialog dialogueJigsawComplete;

    [Header("Extra Panels")]
    [SerializeField] private Quest questPuzzle;
    [SerializeField] private Quest questJigsaw;
    [SerializeField] private QuestManager questManager;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource openPanelSound;

    [Header("Gate")]
    [SerializeField] private GameObject openGate; // Novo sprite para exibir
    [SerializeField] private GameObject closeGate;

    [SerializeField] private GamePauseManager gamePauseManager;

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
        if (questPuzzle.QuestCompleted && !questPuzzle.isRewardGiven)
        {
            DialogueManager.ShowDialogue(dialoguePuzzleComplete);
            audioSource.Play();
            questManager.AddToInventory(questPuzzle);
        }

        if (questJigsaw.QuestCompleted && !questJigsaw.isRewardGiven)
        {
            DialogueManager.ShowDialogue(dialogueJigsawComplete);
            audioSource.Play();
            questManager.AddToInventory(questJigsaw);
            openGate.SetActive(true);
            closeGate.SetActive(false);
        }
    }

    public void OpenClosePlayerQuestPanel(bool value)
    {
        openPanelSound.Play();
        if (value)
        {
            gamePauseManager.PauseGame();
        }
        else
        {
            gamePauseManager.ResumeGame();
        }
        playerQuestPanel.SetActive(value);
    }

    public void OpenPuzzlePanel()
    {
        DialogueManager.CloseDialoguePuzzle();
        SceneManager.LoadScene("PuzzleScene");
    }

    public void OpenJigsawPanel()
    {
        DialogueManager.CloseDialoguePuzzle();
        SceneManager.LoadScene("JigsawScene");
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
}
