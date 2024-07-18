using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UseMana(amount: 1);
        }
    }

    public void RecoverMana(float amount)
    {
        stats.Mana += amount;
        stats.Mana = Mathf.Min(stats.Mana, stats.MaxMana);
    }

    public bool CanRecoverMana()
    {
        return stats.Mana >= 0 && stats.Mana < stats.MaxMana;
    }

    public void UseMana(float amount)
    {
        if (stats.Mana >= amount)
        {
            // atribui o maior valor
            stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);
        }
    }
}