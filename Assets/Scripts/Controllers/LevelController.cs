using AssemblyCSharp.Assets.Scripts.Models;
using Snake.Application;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int _levelIndex;

    public int LevelIndex
    {
        get { return _levelIndex; }
        private set
        {
            if (value >= 3 || value < 0)
            {
                _levelIndex = 0;
            }
            else
            {
                _levelIndex = value;
            }
            PlayerPrefs.SetInt("GameLevel", _levelIndex);
        }
    }

    public LevelModel CurrentLevel { get; private set; }
    private FirstLevelModel FirstLevel { get; set; }
    private SecondLevelModel SecondLevel { get; set; }
    private ThirdLevelModel ThirdLevel { get; set; }

    private List<LevelModel> _levels = new List<LevelModel>();

    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private Light _light;

    private void Awake()
    {
        _levelIndex = PlayerPrefs.GetInt("GameLevel");

        FirstLevel = new FirstLevelModel();
        SecondLevel = new SecondLevelModel();
        ThirdLevel = new ThirdLevelModel();

        _levels.Add(FirstLevel);
        _levels.Add(SecondLevel);
        _levels.Add(ThirdLevel);

        var level = _levels.Find(x => x.Level == _levelIndex);

        CurrentLevel = level;
    }

    private void Start()
    {
        SetLevel(CurrentLevel);
    }

    public void IncreaseLevel()
    {
        CurrentLevel.Level++;

        if (CurrentLevel.Level >= 3)
        {
            CurrentLevel.Level = 0;
        }

        var level = _levels.Find(x => x.Level == CurrentLevel.Level);

        SetLevel(level);
    }

    private void SetLevel(LevelModel level)
    {
        LevelIndex = level.Level;
        CurrentLevel = level;
        _playerController.SetSpeed(CurrentLevel.PlayerSpeed);

        _light.color = CurrentLevel.SunColor;
        //_lightGameObject.transform.rotation = new Quaternion(CurrentLevel.SunRotationX, CurrentLevel.SunRotationY, CurrentLevel.SunRotationZ);
        var x = CurrentLevel.SunRotationX;
        var y = CurrentLevel.SunRotationY;
        var z = CurrentLevel.SunRotationZ;
        _light.transform.rotation = Quaternion.Euler(x, y, z);
        Game.Instance.UpdateLevel(level.Level + 1);
    }
}