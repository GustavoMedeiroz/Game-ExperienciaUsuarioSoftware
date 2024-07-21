using UnityEngine;

public class LockClickableItem : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private PlayerDialog playerDialogLock;
    [SerializeField] private PlayerDialog lockDialog;
    [SerializeField] private DialogueManager dialogManager;

    [Header("Quest")]
    [SerializeField] private Quest quest;
    [SerializeField] private Quest questPuzzle;
    [SerializeField] private Quest questChest;
    [SerializeField] private QuestManager questManager;

    [Header("Audio")]
    [SerializeField] private AudioSource hitAudio;

    private Collider2D objectCollider;

    public Transform player; // Referência ao transform do jogador
    private bool isPlayerNearby = false;

    void Start()
    {
        // Obtenha o collider 2D do objeto
        objectCollider = GetComponent<Collider2D>();

        // Verifica se a missão foi completada e a recompensa foi concedida
        if (quest.QuestCompleted && quest.isRewardGiven)
        {
            // Mostrar sprite novo
            //SpriteRenderer.;
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

        hitAudio.Play();
        if (!questPuzzle.QuestCompleted || !questChest.QuestCompleted)
        {
            dialogManager.ShowDialogue(lockDialog);
        }
        if (!quest.QuestCompleted && questPuzzle.QuestCompleted && questChest.QuestCompleted)
        {
            dialogManager.ShowDialogue(playerDialogLock);
        }
    }
}
