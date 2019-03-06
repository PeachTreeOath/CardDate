using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{

    public float scrollSpeed;
    public int numTiles;
    public Color tileColor;

    private List<GameObject> bgs = new List<GameObject>();
    private float tileSize;
    private float shiftDistance;

    // Use this for initialization
    void Start()
    {
        tileSize = ResourceLoader.instance.scrollBGPrefab.GetComponent<SpriteRenderer>().size.x;
        shiftDistance = tileSize * numTiles;
        float startingXPos = -numTiles * tileSize / 2 + tileSize / 2;
        float startingYPos = -numTiles * tileSize / 2 + tileSize / 2;

        for (int i = 0; i < numTiles; i++)
        {
            float currXPos = startingXPos + tileSize * i;
            for (int j = 0; j < numTiles; j++)
            {
                float currYPos = startingYPos + tileSize * j;
                GameObject newBG = Instantiate(ResourceLoader.instance.scrollBGPrefab);
                newBG.transform.SetParent(transform);
                newBG.transform.position = new Vector2(currXPos, currYPos);
                newBG.GetComponent<SpriteRenderer>().color = tileColor;
                bgs.Add(newBG);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float delta = Time.deltaTime * scrollSpeed;
        Vector2 deltaVector = new Vector2(delta, -delta);
        foreach (GameObject bg in bgs)
        {
            Vector2 pos = bg.transform.position;
            pos += deltaVector;
            if (pos.x > 14)
            {
                pos.x -= shiftDistance;
            }
            if (pos.y < -14)
            {
                pos.y += shiftDistance;
            }
            bg.transform.position = pos;
        }
    }
}
