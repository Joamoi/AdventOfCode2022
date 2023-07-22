using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

public class Tail : MonoBehaviour
{
    public GameObject followKnot;
    public Tilemap tilemap;
    public TileBase tile;

    int followX;
    int followY;
    int ownX;
    int ownY;

    List<string> tailCoord = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        tailCoord.Add("0,0");
    }

    // Update is called once every frame
    void Update()
    {
        followX = (int)followKnot.transform.position.x;
        followY = (int)followKnot.transform.position.y;
        ownX = (int)transform.position.x;
        ownY = (int)transform.position.y;

        if (Mathf.Abs(followX - ownX) == 2 && Mathf.Abs(followY - ownY) == 2)
        {
            transform.position = transform.position + new Vector3(Mathf.Sign(followX - ownX), Mathf.Sign(followY - ownY), 0);
            tailCoord.Add(transform.position.x + "," + transform.position.y);
            tilemap.SetTile(Vector3Int.FloorToInt(transform.position), tile);
        }

        else if (Mathf.Abs(followX - ownX) == 2 && Mathf.Abs(followY - ownY) == 1)
        {
            int goalX = ownX + (int)(Mathf.Sign(followX - ownX) * (Mathf.Abs(followX - ownX) - 1));
            transform.position = new Vector2(transform.position.x, followY);

            do
            {
                transform.position = transform.position + new Vector3(Mathf.Sign(followX - ownX), 0, 0);
                tailCoord.Add(transform.position.x + "," + transform.position.y);
                tilemap.SetTile(Vector3Int.FloorToInt(transform.position), tile);

            } while (transform.position.x != goalX);
        }

        else if (Mathf.Abs(followX - ownX) == 1 && Mathf.Abs(followY - ownY) == 2)
        {
            int goalY = ownY + (int)(Mathf.Sign(followY - ownY) * (Mathf.Abs(followY - ownY) - 1));
            transform.position = new Vector2(followX, transform.position.y);

            do
            {
                transform.position = transform.position + new Vector3(0, Mathf.Sign(followY - ownY), 0);
                tailCoord.Add(transform.position.x + "," + transform.position.y);
                tilemap.SetTile(Vector3Int.FloorToInt(transform.position), tile);

            } while (transform.position.y != goalY);
        }

        else if (Mathf.Abs(followX - ownX) == 2)
        {
            int goalX = ownX + (int)(Mathf.Sign(followX - ownX) * (Mathf.Abs(followX - ownX) - 1));

            do
            {
                transform.position = transform.position + new Vector3(Mathf.Sign(followX - ownX), 0, 0);
                tailCoord.Add(transform.position.x + "," + transform.position.y);
                tilemap.SetTile(Vector3Int.FloorToInt(transform.position), tile);

            } while (transform.position.x != goalX);
        }

        else if (Mathf.Abs(followY - ownY) == 2)
        {
            int goalY = ownY + (int)(Mathf.Sign(followY - ownY) * (Mathf.Abs(followY - ownY) - 1));

            do
            {
                transform.position = transform.position + new Vector3(0, Mathf.Sign(followY - ownY), 0);
                tailCoord.Add(transform.position.x + "," + transform.position.y);
                tilemap.SetTile(Vector3Int.FloorToInt(transform.position), tile);

            } while (transform.position.y != goalY);
        }
    }

    public void ShowResults()
    {
        Debug.Log("amount of tail positions: " + tailCoord.Count);

        string[] uniqueTailCoord = tailCoord.Distinct().ToArray();

        for(int i = 0; i < uniqueTailCoord.Length; i++)
        {
            Debug.Log(uniqueTailCoord[i]);
        }

        Debug.Log("amount of unique tail positions: " + uniqueTailCoord.Length);
    }
}
