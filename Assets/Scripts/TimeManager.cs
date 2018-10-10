using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text Timer;
    public int TotalTime = 100;

    public int TimeLeft { get { return (int)Math.Truncate(_timeLeft); } }
    public bool TimeStopped { get { return _timeStopped; } }
    public float TimeFactor { get { return _timeFactor; } }

    private float _timeLeft;
    private bool _timeStopped;
    private float _timeFactor;

    void Start()
    {
        _timeLeft = TotalTime;
        _timeStopped = false;
        _timeFactor = 1.0f;
    }
	
	void Update()
    {
        UpdateTime();
    }

    public void TimeStart()
    {
        _timeStopped = false;
    }

    public void TimeStop()
    {
        _timeStopped = true;
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

        Timer.text = TimeLeft.ToString();
    }

    private bool CanUpdateTime()
    {
        return (!_timeStopped && !GameManager.instance.GameEnded);
    }
}
