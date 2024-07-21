using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerLife playerLife;

    private void Awake()
    {
        playerLife = GetComponent<PlayerLife>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && stats.Life > 0)
        {
            TakeDamage(amount: 1);
        }
    }

    public void RestoreHealth(float amount)
    {
        stats.Health += amount;
        if (stats.Health >= stats.MaxHealth)
        {
            playerLife.IncrementLife();

            if (stats.Life < stats.MaxLife)
            {
                float h = stats.Health - stats.MaxHealth;
                stats.Health = h;
            }
            else
            {
                stats.Health = stats.MaxHealth;
            }

        }
    }

    public bool CanRestoreHealth()
    {
        return stats.Health >= 0 && stats.Life > 0 &&
                ((stats.Health == 0 && stats.Life < stats.MaxLife) ||
                (stats.Health == stats.MaxHealth && stats.Life < stats.MaxLife) ||
                (stats.Health < stats.MaxHealth && stats.Life <= stats.MaxLife));
    }


    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            if (stats.Life > 1)
            {
                stats.Health = stats.MaxHealth;
            }  // reseta a saude pro próximo coração
            playerLife.DecrementHeart();
        }
    }

}
