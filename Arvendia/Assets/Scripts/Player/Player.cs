
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    [Header("Test")]
    public ItemHealthPotion HealthPotion;
    public ItemManaPotion ManaPotion;

    public PlayerStats Stats => stats;

    public PlayerMana PlayerMana { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }

    private PlayerAnimations animations;
    private PlayerLife playerLife;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
        playerLife = GetComponent<PlayerLife>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (HealthPotion.UseItem())
            {
                Debug.Log("USOU A POÇÃO DE SAÚDE");
            }

            if (ManaPotion.UseItem())
            {
                Debug.Log("USOU A POÇÃO DE MANA");
            }
        }
    }

    public void ResetPlayer()
    {
        stats.ResetPlayer();
        playerLife.UpdateHeartsUI();
        animations.ResetPlayer();
    }
}