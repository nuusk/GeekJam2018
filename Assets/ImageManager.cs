using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public Sprite[] WinSprites;
    public Sprite[] LoseSprites;

    public Sprite GetWinSprite()
    {
        return WinSprites[Random.Range(0, WinSprites.Length)];
    }

    public Sprite GetLoseSprite()
    {
        return LoseSprites[Random.Range(0, LoseSprites.Length)];
    }
}
