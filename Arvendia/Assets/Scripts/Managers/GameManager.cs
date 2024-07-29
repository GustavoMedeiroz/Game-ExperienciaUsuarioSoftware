using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private Player player;
    [SerializeField] private PlayerStats playerStats;

    [Header("Gate")]
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject openGate; // Novo sprite para exibir
    [SerializeField] private GameObject closeGate;

    public Player Player => player;

    public Vector2 playerPosition;

    private void Start()
    {
        Debug.Log("INICIOU");
        LoadPlayerPosition();
        if (quest.QuestCompleted)
        {
            openGate.SetActive(true);
            closeGate.SetActive(false);
        }
        else
        {
            openGate.SetActive(false);
            closeGate.SetActive(true);
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     player.ResetPlayer();
        //     player.transform.position = playerStats.startPosition;
        // }
        // // Atualize a posição do jogador no GameManager
        if (player != null)
        {
            playerStats.playerPosition = player.transform.position;
        }
    }

    public void SavePlayerPosition()
    {
        playerStats.playerPosition = player.transform.position;
        Debug.Log($"Posição do jogador salva: {player.transform.position}");
    }

    public void LoadPlayerPosition()
    {
        if (player != null)
        {
            player.transform.position = playerStats.playerPosition;
            Debug.Log($"Posição do jogador carregada: {player.transform.position}");
        }
    }
}