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

    public void UseMana(float amount)
    {
        if (stats.Mana >= amount)
        {
            // atribui o maior valor
            stats.Mana = Mathf.Max(stats.Mana -= amount, 0f);
        }
    }
}