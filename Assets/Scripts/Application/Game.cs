namespace Snake.Application
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Game : MonoBehaviour
    {
        private static Game _instance;

        public static Game Instance
        {
            get { return _instance; }
        }

        [SerializeField]
        private GameStatus _gameStatus;

        public GameStatus GameStatus
        {
            get { return _gameStatus; }
        }

        [SerializeField]
        private UserInterface _ui;

        private int _score;

        [SerializeField]
        LevelController _levelController;

        private void Start()
        {
            _score = 0;

            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance == this)
            {
                Destroy(gameObject);
            }

            //DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            //_gameStatus = GameStatus.Idle;
            ReadGameStatus();
            //_ui.HideGameplayPanel();
            //Debug.Log($"GameStatus: {_gameStatus}");
            if (_gameStatus == GameStatus.Lose || _gameStatus == GameStatus.Win)
            {
                _ui.HideMainPanel();
                _ui.ShowGameplayPanel();
                StartGame();
            }
        }

        public void EndGame()
        {
            //Debug.Log("EndGame");
            _ui.HideGameplayPanel();

            if (_gameStatus == GameStatus.Lose)
            {
                _ui.ShowLosePanel();
            }
            else if (_gameStatus == GameStatus.Win)
            {
                _ui.ShowWinPanel();
                _levelController.IncreaseLevel();
            }
        }

        public void StartGame()
        {
            Debug.Log($"Current level:{_levelController.CurrentLevel.Name}");
            
            SetGameStatus(GameStatus.InGame);
            //_ui.HideMainPanel();
            //_ui.ShowGameplayPanel();
        }

        public void RestartGame()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public void UpdateScore(int score)
        {
            _score += score;
            if (_score > 0)
            {
                _ui.UpdateScore(_score);
            }
            else
            {
                EndGame();
                _ui.UpdateScore(0);
            }
        }

        public void SetGameStatus(GameStatus status)
        {
            _gameStatus = status;
            PlayerPrefs.SetInt("GameStatus", (int)_gameStatus);
            //Debug.Log($"GameStatus: {_gameStatus}");
        }

        private void ReadGameStatus()
        {
            _gameStatus = (GameStatus)PlayerPrefs.GetInt("GameStatus");
            //Debug.Log($"GameStatus: {_gameStatus}");
        }

        private void OnApplicationQuit()
        {
            SetGameStatus(GameStatus.Quit);
        }
    }
}