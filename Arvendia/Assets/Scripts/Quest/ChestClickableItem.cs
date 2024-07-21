using UnityEngine;

public class ChestClickableItem : MonoBehaviour
{
    [SerializeField] public Sprite newSprite; // Novo sprite para mostrar quando o jogador colidir
    [SerializeField] private Sprite originalSprite; // Sprite original para restaurar
    private SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer

    [Header("Dialogue")]
    [SerializeField] private PlayerDialog playerDialogChest;
    [SerializeField] private PlayerDialog playerDialogChestComplete;
    [SerializeField] private DialogueManager dialogManager;

    [Header("Quest")]
    [SerializeField] private Quest quest;
    [SerializeField] private QuestManager questManager;

    [Header("Audio")]
    [SerializeField] private AudioSource reawardGivenAudio;
    [SerializeField] private AudioSource hitAudio;

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
        if (quest.QuestCompleted && quest.isRewardGiven)
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
        Debug.Log("Quest completa" + quest.QuestCompleted + " - Recompensa dada: " + quest.isRewardGiven);
        if (!quest.QuestCompleted)
        {
            Debug.Log("Quest incompleta e pode mostrar");
            hitAudio.Play();
            dialogManager.ShowDialogue(playerDialogChest);
        }
        else if (quest.QuestCompleted && !quest.isRewardGiven)
        {
            Debug.Log("Quest completa e não foi dada recompensa, pode dar: " + quest.isRewardGiven);
            ShowNewSprite();
            questManager.AddToInventory(quest);
            reawardGivenAudio.Play();
            dialogManager.ShowDialogue(playerDialogChestComplete);
        }
        else if (quest.QuestCompleted && quest.isRewardGiven)
        {
            hitAudio.Play();
            Debug.Log("Quest incompleta e foi dada a recompensa, só mostra dialogo: " + quest.isRewardGiven);
            dialogManager.ShowDialogue(playerDialogChestComplete);
        }
        else
        {
            hitAudio.Play();
            Debug.Log("Opção não disponível.");
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
