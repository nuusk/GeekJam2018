using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerMiniGame : MonoBehaviour, IMiniGame
{
    public Image ResultImage;
    public Slider Slider;
    public float RoundTime = 10f;
    public float TimeLeft;
    public bool Completed = false;

    private AudioSource _audioSource;
    private ImageManager _imageManager;

    void Start()
    {
        TimeLeft = RoundTime;
        _audioSource = GetComponent<AudioSource>();
        _imageManager = GameObject.Find("ImageManager").GetComponent<ImageManager>();
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

        ShowImage(_imageManager.GetLoseSprite());
        Destroy(gameObject, 1.5f);
    }

    public void Win()
    {
        Completed = true;

        ShowImage(_imageManager.GetWinSprite());
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
