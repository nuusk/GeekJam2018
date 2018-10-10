using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text TimeText;

    public int TotalTime = 100;
    public float TimeLeft;
    public bool TimeStopped;
    public float TimeFactor;
    public bool GameEnded;
    public StageType StageType;

    #region Setup

    void Awake()
    {
        SetGameManager();
		Initialize();
    }

	void Update()
    {
        UpdateTime();
	}

    private void Start()
    {
    }

    #endregion

    #region Methods

    public void AddToTime(float value)
    {
        TimeLeft += value;

        if (TimeLeft >= TotalTime)
            TimeLeft = TotalTime;
    }

    public void GameEnd()
    {
        GameEnded = true;
    }

    public void ChangeStage()
    {
        StageType = StageType == StageType.Forge ? StageType.Forge : StageType.Game;
        TimeStopped = !TimeStopped;
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
        TimeLeft = TotalTime;
        TimeStopped = false;
        TimeFactor = 1.0f;
        GameEnded = false;
        StageType = StageType.Game;
    }

    private void UpdateTime()
    {
        if (!CanUpdateTime())
            return;

        TimeLeft -= Time.deltaTime * TimeFactor;

        if (TimeLeft <= 0)
        {
            TimeLeft = 0;
            GameEnd();
        }

        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        if (TimeText != null)
            TimeText.text = ((int)Math.Truncate(Convert.ToDouble(TimeLeft))).ToString();
    }

    private bool CanUpdateTime()
    {
        return (!TimeStopped && !GameEnded);
    }

    #endregion
}
