using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveYonHomies : MonoBehaviour {
    public GameObject ThingToSave;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(ThingToSave);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
