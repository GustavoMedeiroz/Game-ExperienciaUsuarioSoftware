using UnityEngine;

public class AreaBossActivator : MonoBehaviour
{
    [SerializeField] private GameObject panelToActivate; // Painel a ser ativado
    [SerializeField] private string playerTag = "Player"; // Tag do jogador
    private AudioSource audioSource;
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            panelToActivate.SetActive(true);
            if (audioSource)
                audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            panelToActivate.SetActive(false);
            audioSource.Stop();
        }
    }
}
