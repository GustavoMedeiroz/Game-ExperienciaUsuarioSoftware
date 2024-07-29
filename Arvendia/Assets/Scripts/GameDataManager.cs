using UnityEngine;
using BayatGames.SaveGameFree;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private ChestData normalChest1;
    [SerializeField] private ChestData normalChest2;
    [SerializeField] private ChestData normalChest3;
    [SerializeField] private ChestData normalChest4;

    [SerializeField] private Quest questHidenEnigma;
    [SerializeField] private Quest killEnemy;
    [SerializeField] private Quest solveLock;

    [SerializeField] private PlayerStats playerStats;

    private readonly string INVENTORY_KEY_DATA = "MY_INVENTORY_1";


    public void StartNewGame()
    {
        RestNormalChests();
        ResetQuests();
        playerStats.ResetPlayer();
        SaveGame.Delete(INVENTORY_KEY_DATA);

        Debug.Log("Novo jogo iniciado, todos os dados foram resetados.");
    }

    private void ResetQuests()
    {
        questHidenEnigma.ResetQuest();
        killEnemy.ResetQuest();
        solveLock.ResetQuest();
    }

    private void RestNormalChests()
    {
        normalChest1.isRewardGiven = false;
        normalChest2.isRewardGiven = false;
        normalChest3.isRewardGiven = false;
        normalChest4.isRewardGiven = false;
    }
}
