using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector2 MoveDirection => moveDirection;
    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;

    private void Start()
    {
        Debug.Log("Oiiiiiiii...");
        // Restaurar a posição do jogador ao iniciar a cena
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadPlayerPosition();
            Debug.Log("Carregando posição do jogador...");
        }
        else
        {
            Debug.Log("ueeeeeeeeeeeeeeee ");
        }
    }

    private void Awake()
    {
        player = GetComponent<Player>();
        actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }


    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        if (player.Stats.Life <= 0)
        {
            return;
        }

        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }

        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);

    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnDestroy()
    {
        // Salvar a posição do jogador ao destruir o objeto (ao mudar de cena)
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SavePlayerPosition();
        }
    }
}