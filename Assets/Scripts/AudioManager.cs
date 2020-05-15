using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameOver;

    [SerializeField]
    private AudioClip rightAnswer;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void RightAnswer()
    {
        audioSource.PlayOneShot(rightAnswer, 0.5f);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }
}