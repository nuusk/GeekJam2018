using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoseMiniGame : MonoBehaviour, IMiniGame
{
    public Slider Slider;
    public float RoundTime = 3f;
    public float TimeLeft;

    void Start()
    {
        TimeLeft = RoundTime;
    }

    void Update()
    {
        UpdateTime();

        if (TimeLeft <= 0)
        {
            TimeLeft = 0;
            Lose();
        }

        UpdateSlider();
    }

    private void UpdateSlider()
    {
        float progress = Mathf.Clamp01((RoundTime - TimeLeft) / RoundTime);
        Slider.value = progress;
    }

    public void Win()
    {
        Destroy(gameObject, 1.5f);
    }

    public void Lose()
    {
        Destroy(gameObject, 1.5f);
    }

    private void UpdateTime()
    {
        TimeLeft -= Time.deltaTime;
    }
}
