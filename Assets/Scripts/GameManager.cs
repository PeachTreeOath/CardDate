using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CastRay(false);
        }
    }

    private void GenerateItem()
    {
        /*
        if (!AreSquaresFull())
        {
            GameObject obj = Instantiate(ResourceLoader.instance.item);
            Item item = obj.GetComponent<Item>();
            item.Init(0);

            Square emptySquare = null;
            while (!emptySquare)
            {
                int rand = UnityEngine.Random.Range(0, 8);
                if (!squares[rand].isOccupied)
                {
                    emptySquare = squares[rand];
                    item.square = emptySquare;
                }
            }

            emptySquare.isOccupied = true;
            item.transform.position = emptySquare.faceLocation;
        }
        */
    }

    void CastRay(bool isMouseDown)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            ActivityCard handler = hit.collider.GetComponent<ActivityCard>();
            if (handler)
            {
                if (isMouseDown)
                    handler.StartDrag();
                else
                    handler.EndDrag();
            }
        }
    }
}
