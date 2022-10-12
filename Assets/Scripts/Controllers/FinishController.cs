using Snake.Application;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        
        if (player == null)
            return;

        Game.Instance.SetGameStatus(GameStatus.Win);
        Game.Instance.EndGame();
    }
}