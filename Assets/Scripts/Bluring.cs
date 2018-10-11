using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bluring : MonoBehaviour
{
    public float BlurInterval = 5f;
    public float BlurTick = 0.03f;
    public int BlurDuration = 7;
    public float Offset = 0.8f;

    private SpriteRenderer _render;
    private SpriteRenderer _blurRenderer;
    private Renderer _rend;

    void Start()
    {
        //Żeby blur działał trzeba dodać do gameobjectu obiekt z podpiętym SpriteRendererem
         _rend = GetComponent<Renderer>();
        _render = GetComponent<SpriteRenderer>();
        _blurRenderer = transform.Find("BlurRenderer").GetComponent<SpriteRenderer>();

        StartCoroutine(Blur());
    }

    private IEnumerator Blur()
    {
        while (true)
        {
            _blurRenderer.sprite = _render.sprite;
            _render.sprite = null;

            for (int i = 0; i < BlurDuration; i++)
            {
                _blurRenderer.transform.position = GetBlurPosition();
                _rend.enabled = false;

                yield return new WaitForSeconds(BlurTick);

                _rend.enabled = true;
                _blurRenderer.transform.position = GetBlurPosition();

                yield return new WaitForSeconds(BlurTick);
            }

            _render.sprite = _blurRenderer.sprite;
            _blurRenderer.sprite = null;

            yield return new WaitForSeconds(BlurInterval);
        }
    }

    private Vector2 GetBlurPosition()
    {
        return new Vector2(
            _render.transform.position.x + Random.Range(-Offset, Offset),
            _render.transform.position.y + Random.Range(-Offset, Offset));
    }
}
