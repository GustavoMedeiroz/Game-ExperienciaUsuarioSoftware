using System;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{

    [SerializeField] private InventoryItem inventoryItem;
    [SerializeField] private int quantity;

    [Header("Audio")]
    [SerializeField] private AudioSource reawardGivenAudio;
    [SerializeField] private AudioSource hitAudio;

    [SerializeField] private bool isRewardGiven = false;

    private Collider2D objectCollider;

    public Transform player; // Referência ao transform do jogador
    private bool isPlayerNearby = false;

    void Start()
    {
        // Obtenha o collider 2D do objeto
        objectCollider = GetComponent<Collider2D>();
        if (objectCollider == null)
        {
            Debug.LogError("Collider2D não encontrado no objeto " + gameObject.name);
        }
        else
        {
            Debug.Log("OK");
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown chamado");

        if (isPlayerNearby)
        {
            Debug.Log("is player near");


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
        if (!isRewardGiven)
        {
            reawardGivenAudio.Play();
            Inventory.Instance.AddItem(inventoryItem, quantity);
            isRewardGiven = true;
        }
        else
        {
            hitAudio.Play();
        }
    }
}

[Serializable]
public class ItemReward
{
    public InventoryItem Item;
    public int Quantity;
}