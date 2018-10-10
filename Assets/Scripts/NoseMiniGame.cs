using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoseMiniGame : MonoBehaviour, IMiniGame
{
    public Image ResultImage;
    public Slider Slider;
    public float RoundTime = 3f;
    public float TimeLeft;

    private bool _completed = false;
    private ImageManager _imageManager;

    void Start()
    {
        TimeLeft = RoundTime;
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

    public void Win()
    {
        _completed = true;

        ShowImage(_imageManager.GetWinSprite());
        Invoke("BackToGame", 1.5f);
    }

    public void Lose()
    {
        if (_completed)
            return;

        ShowImage(_imageManager.GetLoseSprite());
        Invoke("BackToGame", 1.5f);
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

    private void BackToGame()
    {
        GameManager.instance.ChangeStageToGame();
        Destroy(gameObject);
    }
}
