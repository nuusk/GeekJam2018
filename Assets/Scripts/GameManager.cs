using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int TotalTime = 100;

    public int TimeLeft { get { return (int)Math.Truncate(_timeLeft); } }
    public bool TimeStopped { get { return _timeStopped; } }
    public float TimeFactor { get { return _timeFactor; } }
    public bool GameEnded { get { return _gameEnded; } }
    public StageType StageType { get { return _stageType; } }

    private float _timeLeft;
    private bool _timeStopped;
    private float _timeFactor;
    private bool _gameEnded;
    private StageType _stageType;

    #region Setup

    void Awake()
    {
        SetGameManager();
		Initialize();
    }

	void Update()
    {
        UpdateTime();
        Debug.Log("Update: " + _timeStopped);
	}

    private void Start()
    {
        Debug.Log("start");
        int globalTimeStopped = PlayerPrefs.GetInt("timestopped");
        if (globalTimeStopped == 0)
            _timeStopped = false;
        else
            _timeStopped = false;
    }

    #endregion

    #region Methods

    public void GameEnd()
    {
        _gameEnded = true;
    }

    public void ChangeStageToGame()
    {
        _stageType = StageType.Game;
        _timeStopped = false;
    }

    public void ChangeStageToForge()
    {
        _stageType = StageType.Forge;
        _timeStopped = true;
    }

    #endregion

    #region Helpers

    private void SetGameManager()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }

    private void Initialize()
    {
        _timeLeft = TotalTime;
        //_timeStopped = false;
        _timeFactor = 1.0f;
        _gameEnded = false;
        _stageType = StageType.Game;
    }

    private void UpdateTime()
    {
        if (!CanUpdateTime())
            return;

        _timeLeft -= Time.deltaTime * _timeFactor;

        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            GameManager.instance.GameEnd();
        }
    }

    private bool CanUpdateTime()
    {
        return (!_timeStopped && !_gameEnded);
    }

    public void PlayerPrefabToTrue()
    {
        PlayerPrefs.SetInt("timestopped", 1);
    }

    public void PlayerPrefabToFalse()
    {
        PlayerPrefs.SetInt("timestopped", 0);
    }
    #endregion
}
;