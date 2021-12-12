using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleScript : MonoBehaviour
{
    public Transform emptySpace;
    private Camera camera;
    public PuzzleManager[] tiles;
    private int emptySpaceIndex = 11;
    public static bool solved = false;
    public bool skip = false;



    void Start()
    {
        camera = Camera.main;
        Shuffle();
    }

    void Update()
    {
        Debug.Log(SceneManager.sceneCount);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(a: emptySpace.position, b: hit.transform.position) < 3.5)
                {
                    Vector2 lastEmptySpacePos = emptySpace.position;
                    PuzzleManager thisTile = hit.transform.GetComponent<PuzzleManager>();
                    emptySpace.position = thisTile.targetPos;
                    thisTile.targetPos = lastEmptySpacePos;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }
        if (!solved)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctTiles++;
                }

            }
            if (correctTiles == tiles.Length - 1)
            {
                Debug.Log("solved");
                solved = true;
                SceneManager.LoadScene("Level1");
            }
        }
    }

    public void xButton()
    {
        //skip = true;
        SceneManager.LoadScene("Level1");
    }

    public void Shuffle()
    {
        if(emptySpaceIndex != 11)
        {
            var tileOn11LastPos = tiles[11].targetPos;
            tiles[11].targetPos = emptySpace.position;
            emptySpace.position = tileOn11LastPos;
            tiles[emptySpaceIndex] = tiles[11];
            tiles[11] = null;
            emptySpaceIndex = 11;
        }
        int invertion;
        do
        {
            for (int x = 0; x <= 10; x++)
            {
                if (tiles[x] != null)
                {
                    var lastPos = tiles[x].targetPos;
                    int randomIndex = Random.Range(0, 10);
                    tiles[x].targetPos = tiles[randomIndex].targetPos;
                    tiles[randomIndex].targetPos = lastPos;
                    var tile = tiles[x];
                    tiles[x] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            invertion = GetInversions();
            Debug.Log("shuffled");
        } while (invertion % 2 != 0);
    }

    public int findIndex(PuzzleManager ts)
    {
        for (int x = 0; x < tiles.Length; x++)
        {
            if (tiles[x] != null)
            {
                if (tiles[x] == ts)
                {
                    return x;
                }
            }
        }
        return -1;
    }


    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }


}
