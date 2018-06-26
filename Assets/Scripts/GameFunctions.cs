using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour {
    // Use this for initialization
    public int level=1;
    public int score=0;
    public int lives=3;
    public int bcount=1;
    public bool start = false;
    public bool buttonpressed = false;
    public bool levelclear;
    public Text Level;
    public Text Score;
    public Text Lives;
    public Button m_button;
    void Start ()
    {
        Level.text = "Level: " + level.ToString();
        Score.text = "Score: " + score.ToString();
        Lives.text = "Lives: " + lives.ToString();
        Button btn = m_button;
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Level.text = "Level: " + level.ToString();
        Score.text = "Score: " + score.ToString();
        Lives.text = "Lives: " + lives.ToString();

        if(lives <= 0)
        {
            SceneManager.LoadScene(1);
        }
        if (bcount == 0)
        {
            level++;
            start = false;
            levelclear = true;
        }
    }
    void TaskOnClick()
    {
        buttonpressed = true;
        Destroy(m_button.gameObject);
    }
}
