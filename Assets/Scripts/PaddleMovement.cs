using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    public float speed;
    public float leftboarder;
    public float rightboarder;
    public GameObject GameMaster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        

        float xAxis = Input.GetAxis("Horizontal");
    
        if (GameMaster.GetComponent<GameFunctions>().start==true)
        {
            transform.Translate(new Vector3(xAxis, 0) * Time.deltaTime * speed);
            Vector3 Clamporino = transform.position;
            Clamporino.x = Mathf.Clamp(transform.position.x, leftboarder, rightboarder);
            transform.position = Clamporino;
        }
        if (GameMaster.GetComponent<GameFunctions>().start == false)
        {
            transform.position= new Vector3(0,-7.45f);
        }
    }
}
