using System.Collections;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;
    [SerializeField] private float manaRecoveryAmount = 1f; // quantidade de mana a recuperar
    [SerializeField] private float recoveryInterval = 5f; // intervalo de tempo entre as recuperações de mana
    public float CurrentMana { get; private set; }

    private void Start()
    {
        ResetMana();
        StartCoroutine(RecoverManaOverTime());
    }

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
        CurrentMana = stats.Mana;
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
            CurrentMana = stats.Mana;
        }
    }

    public void ResetMana()
    {
        CurrentMana = stats.MaxMana;
    }

    private IEnumerator RecoverManaOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(recoveryInterval);

            if (CanRecoverMana())
            {
                RecoverMana(manaRecoveryAmount);
            }
        }
    }
}