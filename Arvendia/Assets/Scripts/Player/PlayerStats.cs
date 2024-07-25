using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")]
    public float Mana;
    public float MaxMana;

    [Header("Life")]
    public float Life;
    public float MaxLife;

    [Header("Position")]
    public Vector3 playerPosition;
    public Vector3 startPosition;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalChance;
    public float CriticalDamage;

    public void ResetPlayer()
    {
        Health = MaxHealth;
        Mana = MaxMana;
        Life = MaxLife;
        Level = 1;
        playerPosition = startPosition;
    }
}
