using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour {
    public GameObject GameMaster;
    public int score;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        score = GameMaster.GetComponent<GameFunctions>().score;
	}
}
