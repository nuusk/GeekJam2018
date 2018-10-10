using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseOnCollision : MonoBehaviour
{
    public Sprite Sprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "minigame-bonus")
        {
            if (Sprite != null)
            {
                transform.parent.GetComponent<SpriteRenderer>().sprite = Sprite;
            }

            GameObject miniGameBonusObject = collision.gameObject;

            Rigidbody2D rb = miniGameBonusObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;

            collision.collider.enabled = false;

            IMiniGameBonus miniGameBonus = miniGameBonusObject.GetComponent<IMiniGameBonus>();
            GameManager.instance.AddToTime(miniGameBonus.BonusValue);

            IMiniGame miniGame = GameObject.FindGameObjectWithTag("minigame").GetComponent<IMiniGame>();
            miniGame.Win();
        }
    }
}
