using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.gameOver == true)
        {
            gameOver.SetActive(true);
        }
    }

    public void retry()
    {
        SceneManager.LoadScene("Level1");
        Enemy.gameOver = false;
        PlayerMovement.isFree = false;
        Cloth.hasCloth = false;
        OpenDoor.isOpen = false;
        PuzzleOpen.isOpen = false;
        PuzzleOpen.hasKey = false;
        PuzzleOpen.hasLight = false;
        PuzzleScript.solved = false;
        gameOver.SetActive(false);
        Battery.numOfBattery = 0;
    }
}
