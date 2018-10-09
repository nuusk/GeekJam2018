using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject TimeManager;

    public bool GameEnded { get { return _gameEnded; } }

    private bool _gameEnded;
    private TimeManager _timeManager;

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

    public void ChangeStage(StageType stageType)
    {
        if (stageType == StageType.Game)
            ChangeStateToForge();
        else if (stageType == StageType.Forge)
            ChangeStateToForge();
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

        _timeManager = TimeManager.GetComponent<TimeManager>();        
    }
   

    private void ChangeStateToGame()
    {
        _timeManager.TimeStart();
    }

    private void ChangeStateToForge()
    {
        _timeManager.TimeStop();
    }

    #endregion
}
