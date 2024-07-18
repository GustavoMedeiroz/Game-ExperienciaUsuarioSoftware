
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;

    private PlayerAnimations animations;
    private PlayerLife playerLife;

    private void Awake()
    {
        animations = GetComponent<PlayerAnimations>();
        playerLife = GetComponent<PlayerLife>();
    }

    public void ResetPlayer()
    {
        stats.ResetPlayer();
        playerLife.UpdateHeartsUI();
        animations.ResetPlayer();
    }
}