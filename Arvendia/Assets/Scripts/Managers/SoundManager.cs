using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Area Sounds")]
    [SerializeField] private AudioSource mainAreaSound;
    [SerializeField] private AudioSource monsterAreaSound;
    [SerializeField] private AudioSource desertAreaSound;
    [SerializeField] private AudioSource forestAreaSound;
    [SerializeField] private AudioSource bossAreaSound;

    [Header("Enemy Attack Sounds")]
    [SerializeField] private AudioSource cyclopeAttackSound;
    [SerializeField] private AudioSource snakeAttackSound;
    [SerializeField] private AudioSource reptileAttackSound;
    [SerializeField] private AudioSource frogAttackSound;

    public void StopAllAreaSounds()
    {
        mainAreaSound.volume = 0;
        monsterAreaSound.volume = 0;
        desertAreaSound.volume = 0;
        forestAreaSound.volume = 0;
        bossAreaSound.volume = 0;
    }

    public void StopAllEmeniesSounds()
    {
        cyclopeAttackSound.volume = 0;
        snakeAttackSound.volume = 0;
        reptileAttackSound.volume = 0;
        frogAttackSound.volume = 0;
    }

    public void StopAllSounds()
    {
        StopAllAreaSounds();
        StopAllEmeniesSounds();
    }
}
