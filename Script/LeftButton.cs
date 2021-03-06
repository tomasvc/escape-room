using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour {

    public static bool leftClicked;

	// Use this for initialization
	void Start () {

        leftClicked = false;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            leftClicked = true;
        }

	}
}
