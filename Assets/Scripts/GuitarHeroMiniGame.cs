using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarHeroMiniGame : MonoBehaviour, IMiniGame
{
    public Transform[] Spawners;
    public GameObject MonsterObject;
    public Slider Slider;

    public float SpawnInterval = 0.5f;
    public float RoundTime = 10f;
    public float TimeLeft;

    void Start()
    {
        TimeLeft = RoundTime;
        InvokeRepeating("MonsterFactory", 0, SpawnInterval);
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

    private void MonsterFactory()
    {
        int idx = UnityEngine.Random.Range(0, Spawners.Length);
        Transform spawnPoint = Spawners[idx].transform;

        GameObject monsterObject = Instantiate(MonsterObject, spawnPoint.position, Quaternion.identity, spawnPoint);
        monsterObject.GetComponent<Monster>().SpawnerIndex = idx;
    }
}
