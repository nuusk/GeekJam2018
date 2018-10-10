using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResultImage : MonoBehaviour
{
    public float ScaleX = 7;
    public float ScaleY = 4;

    private bool _enabled = false;

    void OnEnable()
    {
        _enabled = true;
    }

	void Update()
    {
        if (_enabled)
        {
            float stepX = Time.deltaTime * 13;
            float stepY = Time.deltaTime * 8;

            if (transform.localScale.x <= ScaleX)
                transform.localScale = new Vector3(transform.localScale.x + stepX, transform.localScale.y);
            if (transform.localScale.y <= ScaleY)
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + stepY);
        }
    }
}
