using System;
using UnityEngine;

public class NormalChestClickable : MonoBehaviour
{
    [SerializeField] public Sprite newSprite; // Novo sprite para mostrar quando o jogador colidir
    [SerializeField] private Sprite originalSprite; // Sprite original para restaurar
    private SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer

    [Header("Audio")]
    [SerializeField] private AudioSource reawardGivenAudio;
    [SerializeField] private AudioSource hitAudio;

    [Header("Itens")]
    [SerializeField] private ChestData chestData;

    private Collider2D objectCollider;

    public Transform player; // Referência ao transform do jogador
    private bool isPlayerNearby = false;

    void Start()
    {
        // Obtenha o collider 2D do objeto
        objectCollider = GetComponent<Collider2D>();

        // Obtenha o componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Armazene o sprite original
        if (spriteRenderer != null)
        {
            originalSprite = spriteRenderer.sprite;
        }

        // Verifica se a missão foi completada e a recompensa foi concedida
        if (chestData.isRewardGiven)
        {
            // Mostrar sprite novo
            ShowNewSprite();
        }
    }

    private void OnMouseDown()
    {

        if (isPlayerNearby)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider == objectCollider)
            {
                OnObjectClicked();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void OnObjectClicked()
    {
        if (!chestData.isRewardGiven)
        {
            ShowNewSprite();
            reawardGivenAudio.Play();
            if (chestData.weapon != null && chestData.weapon.Quantity > 0)
            {
                Inventory.Instance.AddItem(chestData.weapon.Item, chestData.weapon.Quantity);
            }

            Inventory.Instance.AddItem(chestData.mana.Item, chestData.mana.Quantity);
            Inventory.Instance.AddItem(chestData.health.Item, chestData.health.Quantity);
            //InventoryUI.Instance.OpenCloseInventory();
            chestData.isRewardGiven = true;
        }
        else
        {
            hitAudio.Play();
            return;
        }
    }

    private void ShowNewSprite()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}

[Serializable]
public class ChestItemReward
{
    public InventoryItem Item;
    public int Quantity;
}