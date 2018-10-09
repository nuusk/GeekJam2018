using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text Timer;

    private const string _timerText = "Time: ";

	void Update()
    {
        UpdateTimer();	
	}

    private void UpdateTimer()
    {
        Timer.text = GameManager.instance.TimeLeft.ToString();
    }
}
