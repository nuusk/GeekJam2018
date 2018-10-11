using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseBoundary : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "NoseSticker")
        {
            other.gameObject.GetComponent<NoseSticker>().HorizontalSpeed *= -1;
        }
    }
}
