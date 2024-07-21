using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MonsterAreaAudio : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private AudioSource audioSource;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
