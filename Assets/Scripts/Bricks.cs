using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    SpriteRenderer sprite;
    public Sprite init;
    public Sprite cracked;
    public int points;
    public GameObject GameMaster;
    public int hitcount = 0;
    // Use this for initialization
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = init;


    }

    // Update is called once per frame
    void Update()
    {
        GameObject gm = GameMaster;
        if (hitcount==1)
        {
            sprite.sprite = cracked;
        }
        if (hitcount == 2)
        {
            StartCoroutine(Wait());
            gm.GetComponent<GameFunctions>().score+=points;
            gm.GetComponent<GameFunctions>().bcount --;
            Destroy(gameObject);
        }
    }
    IEnumerator Wait()
    {
        yield return 0;
    }
}
