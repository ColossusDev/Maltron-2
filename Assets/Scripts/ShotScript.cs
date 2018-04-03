using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public float speed = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float realSpeed = speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, realSpeed, 0);

        if (this.gameObject.transform.position.y > 8 || this.gameObject.transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }

	}
}
