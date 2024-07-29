using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    private PlayerAnimations playerAnimations;

    [SerializeField] private GamePauseManager gamePauseManager;
    [SerializeField] private SoundManager audioManager;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GameOverPanelAnim;
    [SerializeField] private GameObject GameOverPanelStatic;
    [SerializeField] private AudioSource GameOverSound;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void Update()
    {
        UpdateHeartsUI();
    }

    public void DecrementHeart()
    {
        if (stats.Life > 0)
        {
            stats.Life--;

            UpdateHeartsUI();

            if (stats.Life <= 0 && stats.Health <= 0)
            {
                PlayerDead();
            }
        }
    }

    public void UpdateHeartsUI()
    {
        for (int i = 0; i < stats.MaxLife; i++)
        {
            if (i < stats.Life)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            hearts[i].enabled = i < hearts.Length;
        }
    }

    private void PlayerDead()
    {

        {
            StartCoroutine(DelayDeathScene());
        }
    }

    private IEnumerator DelayDeathScene()
    {
        playerAnimations.SetDeadAnimation();

        GameOverSound.Play();

        audioManager.StopAllSounds();

        GameOverPanel.SetActive(true);

        GameOverPanelAnim.SetActive(true);

        yield return new WaitForSeconds(4.0f);

        GameOverPanelStatic.SetActive(true);

        GameOverPanelAnim.SetActive(false);
    }

    public void IncrementLife()
    {
        if (stats.Life < stats.MaxLife)
        {
            stats.Life++;
            UpdateHeartsUI();
        }
    }
}
