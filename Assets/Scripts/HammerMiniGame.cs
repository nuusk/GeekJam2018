using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMiniGame : MonoBehaviour
{
    public float RoundTime = 10f;
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
    }

    public void Lose()
    {
        Debug.Log("Przegrałeś");
    }

    public void Win()
    {
        Debug.Log("Wygrałeś");
    }

    private void UpdateTime()
    {
        TimeLeft -= Time.deltaTime;
    }
}
