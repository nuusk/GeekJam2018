using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class KillableArea : MonoBehaviour
{
    public int Index;

    void OnMouseDown()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("minigame-bonus");

        var monster = monsters
            .Select(m => m.GetComponent<Monster>())
            .Where(m => m.SpawnerIndex == Index)
            .FirstOrDefault();

        if (monster != null)
        {
            GameManager.instance.AddToTime(monster.BonusValue);
            monster.Destroy();
        }
        else
        {
            GetComponentInParent<IMiniGame>().Lose();
        }
    }
}
