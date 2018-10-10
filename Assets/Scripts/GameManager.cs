using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject TimeManagerObject;
    public GameObject StageManagerObject;

    public bool GameEnded { get { return _gameEnded; } }
    public TimeManager TimeManager { get { return _timeManager; } }
    public StageManager StageManager { get { return _stageManager; } }

    private bool _gameEnded;
    private TimeManager _timeManager;
    private StageManager _stageManager;

    #region Setup

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

	}

    #endregion

    #region Methods

    public void GameEnd()
    {
        _gameEnded = true;
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
        _gameEnded = false;

        _timeManager = TimeManagerObject.GetComponent<TimeManager>();
        _stageManager = StageManagerObject.GetComponent<StageManager>();
    }

    #endregion
}
