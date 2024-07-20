using System;
using System.Collections;
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
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [Header("Extra Panels")]
    [SerializeField] private GameObject playerQuestPanel;
    [SerializeField] private GameObject puzzlePanel;
    [SerializeField] private DialogueManager DialogueManager;

    [Header("Outro")]
    public PuzzleManager puzzleManager;

    private void Update()
    {
        UpdatePlayerUI();
    }

    public void OpenClosePlayerQuestPanel(bool value)
    {
        playerQuestPanel.SetActive(value);
    }

    public void OpenPuzzlePanel()
    {
        DialogueManager.CloseDialoguePuzzle();
        puzzleManager.SetPlayerActive(false);
        puzzlePanel.SetActive(true);
    }

    public void ClosePuzzlePanel()
    {
        // puzzlePanel.SetActive(false);
        // puzzleManager.SetPlayerActive(true);
        StartCoroutine(ClosePuzzlePanelRoutine());
    }

    private IEnumerator ClosePuzzlePanelRoutine()
    {
        // Suavemente diminuir a opacidade do painel
        CanvasGroup canvasGroup = puzzlePanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = puzzlePanel.AddComponent<CanvasGroup>();
        }

        float duration = 0.2f; // Duração da transição
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / duration);
            yield return null;
        }

        puzzlePanel.SetActive(false);
        canvasGroup.alpha = 1; // Restaurar a opacidade para o próximo uso

        // Exibir animação do player segurando o pedaço da chave
        //playerAnimator.SetTrigger("HoldKeyPiece"); // Assegure-se de que há um trigger chamado "HoldKeyPiece" no Animator

        puzzleManager.SetPlayerActive(true);
    }

    private void UpdatePlayerUI()
    {

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            stats.Health / stats.MaxHealth, 10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount,
            stats.Mana / stats.MaxMana, 10f * Time.deltaTime);

        healthTMP.text = $"{stats.Health} / {stats.MaxHealth}";
        manaTMP.text = $"{stats.Mana} / {stats.MaxMana}";

        //UpdateHeartsUI();
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
