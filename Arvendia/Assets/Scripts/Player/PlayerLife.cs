using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    private PlayerAnimations playerAnimations;

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

        }
        playerAnimations.SetDeadAnimation();
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
