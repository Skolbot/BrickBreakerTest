using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelList : MonoBehaviour {

    public string level1;

    // Use this for initialization
    void Start () {
        //level1 = "- - - - - R BREAK - - - - - R";
        level1 =
        @"R R R R R R R R R R R BREAK~
          R R R R R R R R R R R BREAK~
          O O O O O O O O O O O BREAK~
          O O O O O O O O O O O BREAK~
          G G G G G G G G G G G BREAK~
          G G G G G G G G G G G BREAK~";
        /*level1 =
        @"R - - - - R - - - - R BREAK~
          - R - R - R - R - R - BREAK~
          - - O - - O - - O - - BREAK~
          - - - O O O O O - - - BREAK~
          - G G G - - - G G G - BREAK~
          G - G - G G G - G - G BREAK~";*/
    }

    // Update is called once per frame
    void Update () {
		
	}
}
