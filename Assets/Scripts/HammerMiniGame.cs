using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerMiniGame : MonoBehaviour, IMiniGame
{
    public Sprite WinSprite;
    public Sprite LoseSprite;
    public Image ResultImage;
    public Slider Slider;
    public float RoundTime = 10f;
    public float TimeLeft;

    private bool Completed = false;

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

    public void Lose()
    {
        if (Completed)
            return;

        ShowImage(LoseSprite);
        Destroy(gameObject, 1.5f);
    }

    public void Win()
    {
        Completed = true;

        ShowImage(WinSprite);
        Destroy(gameObject, 1.5f);
    }

    private void ShowImage(Sprite sprite)
    {
        ResultImage.sprite = sprite;
        ResultImage.transform.localScale = Vector3.zero;
        ResultImage.enabled = true;
    }

    private void UpdateTime()
    {
        TimeLeft -= Time.deltaTime;
    }
}
