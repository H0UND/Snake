using Snake.Application;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        var player = other.GetComponent<PlayerController>();
        
        if (player == null)
            return;

        Game.Instance.SetGameStatus(GameStatus.Win);
        Game.Instance.EndGame();
    }
}