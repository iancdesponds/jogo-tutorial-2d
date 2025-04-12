using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3;
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        lives--;

        if (lives <= 0)
        {
            GameController.IsGameOver = true;
            //Time.timeScale = 0f;
        }
    }
}
