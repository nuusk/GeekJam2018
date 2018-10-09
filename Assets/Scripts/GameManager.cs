using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject TextManager;

    [Space]
    public int TotalTime = 100;

    public int TimeLeft { get { return (int)Math.Truncate(_timeLeft); } }
    public bool TimeStopped { get { return _timeStopped; } }
    public bool GameEnded { get { return _gameEnded; } }
    public float TimeFactor { get { return _timeFactor; } }

    private float _timeLeft;
    private bool _timeStopped;
    private bool _gameEnded;
    private float _timeFactor;

    void Awake()
    {
        SetGameManager();
    }

	void Start()
    {
		Initialize();
	}
	
	void Update()
    {
        UpdateTime();
	}

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
        _timeStopped = false;
        _gameEnded = false;
        _timeFactor = 1.0f;
    }

    private void UpdateTime()
    {
        if (!CanUpdateTime())
            return;

        _timeLeft -= Time.deltaTime * _timeFactor;

        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            GameEnd();
        }
    }

    private bool CanUpdateTime()
    {
        return (!_gameEnded && !_timeStopped);
    }
    
    private void GameEnd()
    {
        _gameEnded = true;
    }
}
