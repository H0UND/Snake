using UnityEngine;
using UnityEngine.UI;

namespace Snake.Scripts.Views.UserInterface
{
    public class GameplayPanel : PanelView
    {
        [SerializeField]
        private Text _score;
        private Text _level;

        private void Start()
        {
            if (_score == null)
            {
                Debug.LogError("Text score is null");
            }
        }

        public void UpdateScore(int score)
        {
            _score.text = score.ToString();
        }

        public void UpdateLevel(int level)
        { 
            _level.text = level.ToString();
        }
    }
}