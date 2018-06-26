using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public GameObject self;
    bool gamestart;
    public float xstart;
    public float ystart;
    public float xincrement;
    public float yincrement;
    public GameObject RedBrick;
    public GameObject OrangeBrick;
    public GameObject GreenBrick;
    public GameObject GameMaster;
    // Use this for initialization

    void SpawnLevel()
    {
        string grid = self.GetComponent<LevelList>().level1;

        float x = xstart;
        float y = ystart;
        string[] bricks = grid.Split(' ', '~');
        foreach (string word in bricks)
        {
            if (word == "R")
            {
                Instantiate(RedBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;

            }
            if (word == "O")
            {
                Instantiate(OrangeBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;
            }
            if (word == "G")
            {
                Instantiate(GreenBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;
            }
            if (word == "-")
            {
                x += xincrement;
            }
            if (word == "BREAK")
            {
                y -= yincrement;
                x = xstart;
            }

        }

    }


    void Start()
    {
        string grid = self.GetComponent<LevelList>().level1;
        float x = xstart;
        float y = ystart;
        string[] bricks = grid.Split(' ', '~');
        foreach (string word in bricks)
        {
            if (word == "R")
            {
                Instantiate(RedBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;

            }
            if (word == "O")
            {
                Instantiate(OrangeBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;
            }
            if (word == "G")
            {
                Instantiate(GreenBrick, new Vector3(x, y), Quaternion.identity);
                x += xincrement;
                GameMaster.GetComponent<GameFunctions>().bcount++;
            }
            if (word == "-")
            {
                x += xincrement;
            }
            if (word == "BREAK")
            {
                y -= yincrement;
                x = xstart;
            }

        }
        GameMaster.GetComponent<GameFunctions>().bcount--;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameMaster.GetComponent<GameFunctions>().levelclear==true)
        {
            StartCoroutine(Wait());
            SpawnLevel();
            GameMaster.GetComponent<GameFunctions>().levelclear = false;
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }


}
