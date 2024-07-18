using System.Collections;
using System.Collections.Generic;
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

    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            stats.Health = stats.MaxHealth;  // Reset health for the next heart
            playerLife.DecrementHeart();
        }
    }


}
