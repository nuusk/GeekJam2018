using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDestroyer : MonoBehaviour
{
    public bool LoseOnCollision = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "minigame-bonus")
        {
            IMiniGameBonus miniGameBonus = collision.gameObject.GetComponent<IMiniGameBonus>();
            IMiniGame miniGame = collision.gameObject.GetComponentInParent<IMiniGame>();

            miniGameBonus.Destroy();
            
            if (LoseOnCollision)
                miniGame.Lose();
        }
    }
}
