using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _timerText;

    private void Start()
    {
        _timerText = GetComponent<Text>();
    }

    void Update()
    {
        _timerText.text = GameManager.instance.TimeLeft.ToString();
    }
}
