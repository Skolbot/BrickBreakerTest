using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour {
    public bool found;
    public Text scoredisplay;
    public int score;
	// Use this for initialization
	void Start () {
        found = false;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject scoresaver = GameObject.Find("ScoreSaver");
        score = scoresaver.GetComponent<ScoreSaver>().score;
        scoredisplay.text = "Your Score: " + score.ToString();

	}
}
