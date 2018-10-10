using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupGenerator : MonoBehaviour {

    protected GameObject[] tilesets;
    public int soupFrequency = 1;
    public GameObject soupPrefab;

    // Use this for initialization
    void Start () {
        tilesets = GameObject.FindGameObjectsWithTag("TilesetPrefab");

        for (int i = 0; i < tilesets.Length; i++)
        {
            if (i % soupFrequency == 0)
            {
                Instantiate(
                    soupPrefab, 
                    new Vector3(tilesets[i].transform.position.x, tilesets[i].transform.position.y, tilesets[i].transform.position.z), 
                    Quaternion.identity
                );
            }
        }
	}
}
