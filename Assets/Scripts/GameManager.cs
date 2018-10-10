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
    public GameObject[] MiniGames;

    public int TotalTime = 100;
    public float TimeLeft;
    public bool TimeStopped;
    public float TimeFactor;
    public bool GameEnded;
    public StageType StageType;

    private AudioSource _audioSource;

    #region Setup

    void Awake()
    {
        SetGameManager();
		Initialize();
    }

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && StageType == StageType.Game)
            ChangeStageToForge();

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

    public void GameOver()
    {
        GameEnded = true;
        _audioSource.Play();
    }

    public void ChangeStageToGame()
    {
        StageType = StageType.Game;
        TimeStopped = false;
        TimeText.enabled = true;
    }

    public void ChangeStageToForge()
    {
        StageType = StageType.Forge;
        TimeStopped = true;
        TimeText.enabled = false;

        int idx = UnityEngine.Random.Range(0, MiniGames.Length);
        Instantiate(MiniGames[idx], transform.parent);
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
        _audioSource = GetComponent<AudioSource>();
    }

    private void UpdateTime()
    {
        if (!CanUpdateTime())
            return;

        TimeLeft -= Time.deltaTime * TimeFactor;

        if (TimeLeft <= 0)
        {
            TimeLeft = 0;
            GameOver();
        }

        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        if (TimeText != null)
            TimeText.text = Math.Floor(TimeLeft).ToString();
    }

    private bool CanUpdateTime()
    {
        return (!TimeStopped && !GameEnded);
    }

    #endregion
}
