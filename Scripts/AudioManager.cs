using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BoxDropp;
    public AudioClip GameOver;
    public AudioClip GetDiamond;

    public AudioSource BackSource;

    public void BoxDroppSound()
    {
        audioSource.clip = BoxDropp;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = GameOver;
        audioSource.Play();
    }

    public void DiamondSound()
    {
        audioSource.clip = GetDiamond;
        audioSource.Play();
    }
}
