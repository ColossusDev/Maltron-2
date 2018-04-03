using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ship;

	// Use this for initialization
	void Start () {
        GameObject go = Instantiate(ship);
        go.name = "playerShip";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
