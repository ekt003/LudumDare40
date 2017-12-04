using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableAsset : MonoBehaviour {

    //whether or not the building has been clicked
    public bool isClicked;

	// Use this for initialization
	void Start () {
        isClicked = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseDown()
    {
        isClicked = true;
    }

    public void TurnOff()
    {
        isClicked = false;
    }
}
