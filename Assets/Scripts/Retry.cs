using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {
    public Button m_button;
    // Use this for initialization
    void Start () {
        Button btn = m_button;
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void TaskOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
