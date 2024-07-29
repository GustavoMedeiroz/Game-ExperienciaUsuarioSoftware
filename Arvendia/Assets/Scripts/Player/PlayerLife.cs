using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

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
          StartCoroutine(DelayDeathScene());
        }

        playerAnimations.SetDeadAnimation();
    }

     private IEnumerator DelayDeathScene()
    {
        // Executa a animação de morte
        //playerAnimations.SetTrigger("Dead"); // Supondo que "Dead" é o trigger para a animação de morte

        // Aguarda 3 segundos
        yield return new WaitForSeconds(2.0f);

        // Carrega a cena de morte
        SceneManager.LoadScene("DeathScene");
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
