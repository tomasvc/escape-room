using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour {

    public static bool rightClicked;

    // Use this for initialization
    void Start () {

        rightClicked = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            rightClicked = true;
        }

    }
}
