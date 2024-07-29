using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class EnemyHealth : MonoBehaviour, IDamageable
{
    public static event Action OnEnemyDeadEvent;

    [Header("Config")]
    [SerializeField] private float health;
    [SerializeField] private bool isBoss;

    [Header("Bars")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private GameObject vitoriaPanel;

    public float CurrentHealth { get; private set; }

    private Animator animator;
    private Rigidbody2D rb2D;
    private EnemyBrain enemyBrain;
    private EnemyLoot enemyLoot;
    private EnemySelector enemySelector;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyLoot = GetComponent<EnemyLoot>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    private void Update()
    {
        if (isBoss)
        {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            CurrentHealth / health, 10f * Time.deltaTime);
            if (CurrentHealth < 0)
            {
                healthTMP.text = $"{0} / {health}";
            }
            else
            {
                healthTMP.text = $"{CurrentHealth} / {health}";
            }
        }

    }
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0f)
        {
            Debug.Log("MORREU");
            animator.SetTrigger("Dead");
            enemyBrain.enabled = false;
            enemySelector.NoSelectionCallback();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            OnEnemyDeadEvent?.Invoke();

            if (isBoss)
            {
                vitoriaPanel.SetActive(true);
                StartCoroutine(DelayDeathScene());
            }

            if (!isBoss)
            {
                QuestManager.Instance.AddProgress("KillEnemy", 1);
            }
        }
        else
        {
            DamageManager.Instance.ShowDamageText(amount, transform);
        }
    }

    private IEnumerator DelayDeathScene()
    {


        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("VictoryScene");
    }


    private void DisableEnemy()
    {
        animator.SetTrigger("Dead");
        enemyBrain.enabled = false;
        enemySelector.NoSelectionCallback();
        rb2D.bodyType = RigidbodyType2D.Static;
        OnEnemyDeadEvent?.Invoke();
        //GameManager.Instance.AddPlayerExp(enemyLoot.ExpDrop);
    }
}