using Snake.Application;
using Snake.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;

    private List<GameObject> _tails;

    [SerializeField]
    private GameObject _tailPrefab;

    private FollowPlayer _followPlayer;

    //public PlayerStatus PlayerStatus;

    private Vector3 Position
    {
        get
        {
            return gameObject.transform.localPosition;
        }
        set
        {
            gameObject.transform.localPosition = value;
        }
    }

    public void StartMoving()
    {
        //PlayerStatus = PlayerStatus.Walking;
    }

    public void StopMoving()
    {
        //PlayerStatus = PlayerStatus.Stand;
        //Debug.Log("StopMoving");
        //Debug.Log($"PlayerStatus is {PlayerStatus}");
    }

    public void AddTail(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var tail = Instantiate(_tailPrefab);
            if (_tails.Count > 0)
            {
                _tails[_tails.Count - 1].GetComponent<FollowPlayer>().FollowMe = tail;
            }
            else
            {
                _followPlayer.FollowMe = tail;
            }
            _tails.Add(tail);
        }
    }

    public void RemoveTail(int gone)
    {
        for (int i = 0; i < gone; i++)
        {
            if (_tails.Count != 0)
            {
                Destroy(_tails[_tails.Count - 1]);
                _tails.RemoveAt(_tails.Count - 1);
            }
        }
        if (_tails.Count <= 0)
        {
            Game.Instance.SetGameStatus(GameStatus.Lose);
            Game.Instance.EndGame();
            StopMoving();
            Debug.Log($"Remove count: {gone}. Tail count: {_tails.Count}");
            return;
        }
    }

    internal void SetSpeed(float playerSpeed)
    {
        _speed = playerSpeed;
    }

    private void Awake()
    {
        _tails = new List<GameObject>();
        _followPlayer = GetComponent<FollowPlayer>();
    }

    private void Start()
    {
        //PlayerStatus = PlayerStatus.Stand;
    }

    private void FixedUpdate()
    {
        if (Game.Instance.GameStatus == GameStatus.InGame)
        {
            float leftBorder = -6.0f;
            float rightBorder = 6.0f;

            Walk(leftBorder, rightBorder);
        }
    }

    private void Walk(float leftBorder, float rightBorder)
    {
        Position = new Vector3(Position.x, 0f, Position.z + _speed * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 1)
        {
            if (Position.x <= rightBorder)
            {
                Position = new Vector3(
                    Position.x + _speed * Time.deltaTime,
                    0f,
                    Position.z);
            }
        }

        if (horizontal == -1)
        {
            if (Position.x >= leftBorder)
            {
                Position = new Vector3(
                    Position.x - _speed * Time.deltaTime,
                    0f,
                    Position.z);
            }
        }
    }
}