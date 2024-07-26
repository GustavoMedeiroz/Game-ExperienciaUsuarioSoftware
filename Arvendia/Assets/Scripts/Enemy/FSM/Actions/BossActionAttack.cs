using System;
using UnityEngine;

public class BossActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBtwAttacks;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject projectilePrefab; // Prefab do projétil
    [SerializeField] private Transform firePoint; // Ponto de origem do projétil
    [SerializeField] private ActionPatrol actionPatrol;

    private EnemyBrain enemyBrain;
    private float timer;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
        actionPatrol.Act();
    }

    private void AttackPlayer()
    {
        if (enemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            FireProjectile();
            PlayAttackSound();
            timer = timeBtwAttacks;
        }
    }

    private void FireProjectile()
    {
        if (projectilePrefab == null || firePoint == null) return;

        GameObject projectileInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Direction = (enemyBrain.Player.transform.position - firePoint.position).normalized;
            projectile.Damage = damage;
            projectile.Shooter = gameObject; // Define o inimigo como o atirador
        }
    }

    private void PlayAttackSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduza o som de ataque
        }
    }
}
