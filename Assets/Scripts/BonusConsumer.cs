using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusConsumer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "minigame-bonus")
        {
            IMiniGameBonus miniGameBonus = collision.gameObject.GetComponent<IMiniGameBonus>();
            IMiniGame miniGame = GameObject.FindGameObjectWithTag("minigame").GetComponent<IMiniGame>();

            GameManager.instance.AddToTime(miniGameBonus.BonusValue);
            miniGameBonus.Destroy();
            miniGame.Win();
        }
    }
}
