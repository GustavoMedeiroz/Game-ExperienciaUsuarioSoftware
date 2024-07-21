using UnityEngine;

public class PuzzleClickableItem : MonoBehaviour
{
    [SerializeField] public Sprite newSprite; // Novo sprite para mostrar quando o jogador colidir
    [SerializeField] private Sprite originalSprite; // Sprite original para restaurar
    private SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer
    [SerializeField] private UIManager uIManager;

    [Header("Dialogue")]
    [SerializeField] private PlayerDialog playerDialogPuzzle;
    [SerializeField] private PlayerDialog playerDialogComplete;
    [SerializeField] private DialogueManager dialogManager;

    [Header("Quest")]
    [SerializeField] private Quest quest;

    [Header("Audio")]
    [SerializeField] private AudioSource hitAudio;

    private Collider2D objectCollider;

    public Transform player; // Referência ao transform do jogador
    private bool isPlayerNearby = false; // Distância mínima para permitir a interação


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
    }

    private void OnMouseDown()
    {

        if (isPlayerNearby)
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider == objectCollider)
            {
                // Chame a função de interação aqui
                OnObjectClicked();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = true;

            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = originalSprite;
            }
        }
    }

    public void TESTE()
    {

    }

    public void OnObjectClicked()
    {
        hitAudio.Play();
        if (uIManager)
        {
            if (!quest.QuestCompleted)
            {
                dialogManager.ShowDialogue(playerDialogPuzzle);
            }
            else
            {

                dialogManager.ShowDialogue(playerDialogComplete);
            }
        }
        else
        {
            Debug.Log("Não tem UIManager");
        }
    }
}
