using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Vector3 targetPos;
    private Vector3 correctPos;
    private SpriteRenderer sprite;
    public bool inRightPlace;
    public int number;
    // Start is called before the first frame update
    void Awake()
    {
        targetPos = transform.position;
        correctPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(a: transform.position, b: targetPos, t: 0.05f);
        if(targetPos == correctPos)
        {
            inRightPlace = true;
        }
        else
        {
            inRightPlace = false;
        }
    }
}
