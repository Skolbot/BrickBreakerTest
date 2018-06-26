using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public float xCor, yCor, speed;
    bool hit_orange = false;
    bool hit_red = false;
    public Vector2 CurDir;
    public Vector2 angles;
    public GameObject Arrow;
    public GameObject GameMaster;
    public float x;
    public float y;
    public float testdif;
    public float multiplier;
    public float angle;
    public float newangle;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(xCor, yCor);
        CurDir = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMaster.GetComponent<GameFunctions>().buttonpressed && GameMaster.GetComponent<GameFunctions>().start == false)
        {
            StartCoroutine(Wait());
        }

        if (GameMaster.GetComponent<GameFunctions>().start == false)
        {
            y = Mathf.Cos(Arrow.GetComponent<GuideArrow>().Clamporino.z*Mathf.Deg2Rad);
            x = -Mathf.Sin(Arrow.GetComponent<GuideArrow>().Clamporino.z*Mathf.Deg2Rad);
            CurDir = new Vector2(x, y);
        }
        if (GameMaster.GetComponent<GameFunctions>().start == true)
        {
            transform.Translate(CurDir * Time.deltaTime * speed);
        }
        if (GameMaster.GetComponent<GameFunctions>().levelclear == true)
        {
            if (hit_red == true)
            {
                speed = speed / 1.5f;
                hit_red = false;
            }
            if (hit_orange==true)
            {
                speed = speed / 1.5f;
                hit_orange = false;
            }
            StartCoroutine(Wait());
        }
    }
    // Update is called when hits
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject gm = GameMaster;
        if ((col.gameObject.tag == "Wall") || (col.gameObject.tag == "Roof"))
        {
            CurDir = Vector2.Reflect(CurDir, col.contacts[0].normal);
        }
        if (col.gameObject.tag == "Paddle")
        {
            Vector3 ball_pos = gameObject.transform.position;
            Vector3 col_pos = col.transform.position;
            testdif = ball_pos.x - col_pos.x;
            float padmin = .5f;
            float padmax = 2.2f;
            float multmin = 1;
            float multmax = 2;
            multiplier = 1/((Mathf.Abs(testdif) - padmin) / (padmax - padmin) * (multmax - multmin) + multmin);
            if (Mathf.Abs(testdif) < .5)
            {
                CurDir = new Vector2(CurDir.x, -CurDir.y);
            }
            else if (Mathf.Abs(testdif) <= 2.2)
            {
                angle = Mathf.Asin(-CurDir.y)*Mathf.Rad2Deg;
                newangle = angle * (multiplier);
                if (CurDir.x > 0)
                {
                    CurDir = new Vector2(Mathf.Cos(newangle * Mathf.Deg2Rad), Mathf.Sin(newangle * Mathf.Deg2Rad));
                }
                else
                {
                    CurDir = new Vector2(-Mathf.Cos(newangle * Mathf.Deg2Rad), Mathf.Sin(newangle * Mathf.Deg2Rad));
                }

            }
            else
            {
                CurDir = Vector2.Reflect(CurDir, col.contacts[0].normal);
            }

        }
        if (col.gameObject.tag == "Brick" && GameMaster.GetComponent<GameFunctions>().start == true)
        {
            Vector3 ball_pos = gameObject.transform.position;
            Vector3 col_pos = col.transform.position;
            CurDir = Vector2.Reflect(CurDir, col.contacts[0].normal);
            if(ball_pos.y<col_pos.y && CurDir.y > 0)
            {
                CurDir.y=-CurDir.y;
            }
            col.gameObject.GetComponent<Bricks>().hitcount++;
            if(col.gameObject.GetComponent<Bricks>().points==3 && hit_orange == false)
            {
                speed *= 1.5f;
                hit_orange = true;
            }
            if (col.gameObject.GetComponent<Bricks>().points == 5 && hit_red == false)
            {
                speed *= 1.5f;
                hit_red = true;
            }
        }
        if (col.gameObject.tag == "Floor")
        {

            GameMaster.GetComponent<GameFunctions>().start = false;
            gm.GetComponent<GameFunctions>().lives--;
            if (gm.GetComponent<GameFunctions>().lives == 0)
            {
                Destroy(this.gameObject);
            }
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
        transform.position = new Vector3(xCor, yCor);
        CurDir = new Vector2(1, 1);
        yield return new WaitForSeconds(3);
        GameMaster.GetComponent<GameFunctions>().start = true;
    }
}
