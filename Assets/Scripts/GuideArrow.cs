using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideArrow : MonoBehaviour {
    public GameObject GameMaster;
    public float leftrlock;
    public float rightrlock;
    public float speed;
    public float xCor;
    public float yCor;
    public Vector3 Clamporino;
    public Text newlevel;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(xCor, yCor);
    }
	
	// Update is called once per frame
	void Update () {
        float zAxis = -Input.GetAxis("Horizontal");
        if (GameMaster.GetComponent<GameFunctions>().start == false && GameMaster.GetComponent<GameFunctions>().buttonpressed == true)
        {
            newlevel.text = "Level: " + GameMaster.GetComponent<GameFunctions>().level.ToString();
            gameObject.GetComponent<Renderer>().enabled = true;
            transform.Rotate(new Vector3(0,0,zAxis) * Time.deltaTime *speed );
            Clamporino = gameObject.transform.eulerAngles;
            Clamporino.z = (Clamporino.z > 180) ? Clamporino.z - 360 : Clamporino.z;
            Clamporino.z = Mathf.Clamp(Clamporino.z, leftrlock, rightrlock);
            gameObject.transform.rotation = Quaternion.Euler(Clamporino);
        }
        if (GameMaster.GetComponent<GameFunctions>().start == true || GameMaster.GetComponent<GameFunctions>().buttonpressed == false)
        {
            transform.Rotate(new Vector3(0, 0, 0));
            newlevel.text = "";
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
